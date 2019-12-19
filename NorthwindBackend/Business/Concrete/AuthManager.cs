using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using MailKit.Net.Smtp;

using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }


        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if(userToCheck==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if(!HashingHelper.VerifyPasswordHash(userForLoginDto.sifre,userToCheck.Sifrele,userToCheck.SifreCoz))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
            
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string sifre)
        {
            byte[] sifrele, sifrecoz;
            HashingHelper.CreatePasswordHash(sifre, out sifrele, out sifrecoz);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                AdSoyad = userForRegisterDto.AdSoyad,
                
                KullaniciAdi = userForRegisterDto.KullaniciAdi,
                Telefon = userForRegisterDto.Telefon,
                Tarih = DateTime.Now,
                Sehir = userForRegisterDto.Sehir,
                Aktif = true,
                Sil = false,
                Sifrele = sifrele,
                SifreCoz = sifrecoz,
                IsAdmin = true,
            };
            _userService.AddUser(user);
            this.SendMail(userForRegisterDto.Email);
            return new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IResult SendMail(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Piton-Arge", "pro"));
            message.To.Add(new MailboxAddress("addi", email));
            message.Subject = "Piton-EYS";
            message.Body = new TextPart("plain")
            {
                Text = "Piton-Arge Etkinlik Yönetim Sistemini kaydoldunuz."
        };
            
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("addidagli@gmail.com", "t0ps3cr3t");
                client.Send(message);

                client.Disconnect(true);
            }

            return new SuccessResult();
        }

        public IResult UserExist(string email)
        {
            if(_userService.GetByMail(email)!= null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
