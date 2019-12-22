using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IFirmaCalisaniService _firmaCalisaniService;
        
        public UsersController(IUserService userService, IFirmaCalisaniService firmaCalisaniService)
        {
            _firmaCalisaniService = firmaCalisaniService;
            _userService = userService;
        }

        [HttpPost("adduser")]
        public IActionResult Add(User user)
        {
            var userExists = _userService.UserExist(user.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            //User _user = new User();
            //UserDataUpdate(_user, user);
            var result = _userService.AddUser(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteuser")]
        public IActionResult Delete(User user)
        {
            var result = _userService.DeleteUser(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateuser")]
        public IActionResult Update(UserUpdateDto user, int firmaId)
        {
            //User _user = new User();
            // UserDataUpdate(_user, user);
            //if(user.Pas)
            var response = _userService.GetUserById(user.Id);
            if(!response.Success || response.Data == null)
                return BadRequest("Kullanıcı bulunamadı");

            var tempUser = response.Data;

            if (user.Sifre != null && user.Sifre != "")
            {
                byte[] sifrele, sifrecoz;
                HashingHelper.CreatePasswordHash(user.Sifre, out sifrele, out sifrecoz);
                tempUser.Sifrele = sifrele;
                tempUser.SifreCoz = sifrecoz;
            }

            tempUser.AdSoyad = user.AdSoyad;
            tempUser.Email = user.Email;
            tempUser.Sehir = user.Sehir;
            tempUser.KullaniciAdi = user.KullaniciAdi;
            tempUser.fid = user.fid;
            tempUser.IsAdmin = user.IsAdmin;
            tempUser.Telefon = user.Telefon;
            tempUser.Aktif = user.Aktif;

            var result = _userService.UpdateUser(tempUser, firmaId);
            if (result.Success)
            {
                //FirmaCalisani firmaCalisani = new FirmaCalisani();
               // firmaCalisani.FirmaId = user.firmaId;
                //firmaCalisani.KullaniciId = user.id;
                //firmaCalisani.IsDelege = false;
                //var resultCalisan = _firmaCalisaniService.AddFirmaCalisani(firmaCalisani);
                //if (resultCalisan.Success)
                {
                    //return Ok(resultCalisan.Message);
                }
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getalluser")]
        public IActionResult GetList()
        {        
                var result = _userService.GetAllUser();
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
        }

        [HttpGet("getuserbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _userService.GetUserById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getuserbyfirmaid")]
        public IActionResult GetListFilter(int firmaId)
        {
            var result = _firmaCalisaniService.GetUserIdsByFirmaId(firmaId);
            if (result.Success)
            {
                var resultUser = _userService.GetUsersByUserIds(result.Data);
                if (resultUser.Success)
                {
                    return Ok(resultUser.Data);
                }
                else
                {
                    return BadRequest(resultUser.Message);
                }
            }
            return BadRequest(result.Message);
        }

        /*void UserDataUpdate(User _user, Entities.Dtos.UserOut user)
        {
            _user.AdSoyad = user.adSoyad;
            _user.KullaniciAdi = user.kullaniciAdi;
            _user.Email = user.email;
            _user.Sifre = user.sifre;
            _user.Tarih = user.tarih;
            _user.Telefon = user.telefon;
        }*/
    }
}