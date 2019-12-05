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
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
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

        /*public IDataResult<List<User>> GetListOrganizatorByOrganization(int organizationId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.organizationId == organizationId));
        }

        public IDataResult<List<User>> GetListUserByActivity(int activityId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.activityId == activityId));
        }

        public IDataResult<List<User>> GetListUserByCompany(int companyId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.companyId == companyId));
        }
        */



    }
}
