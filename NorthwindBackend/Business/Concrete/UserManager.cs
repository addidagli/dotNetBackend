using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            //_userDal.AddFirmaCalisani(user, firmaId);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult UpdateUser(User user, int? firmaId)
        {
            _userDal.Update(user);
            _userDal.AddFirmaCalisani(user, firmaId);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAllUser()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetUser().ToList());
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<User> GetUserById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id));
        }

        /*public IDataResult<List<User>> GetUserByEtkinlikId(int etkinlikId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetUser(p => p.EtkinlikId == etkinlikId).ToList());
        }*/


            //aynı tabloda bulunan bi değere göre liste çekmek için
        //public IDataResult<List<User>> GetUserByFirmaId(int fid)
        //{
        //    return new SuccessDataResult<List<User>>(_userDal.GetListFilter(p => p.fid == fid).ToList());

        //}

        public IDataResult<List<User>> GetUsersByUserIds(List<int> userIds)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetListFilter(p => userIds.Contains(p.Id)).ToList());
        }

        public IResult UserExist(string email)
        {
            if (this.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }



        /*public IDataResult<List<User>> GetUserByFirmaId(int firmaId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetUser(p => p.EtkinlikId == etkinlikId).ToList());
        }*/
    }
}
