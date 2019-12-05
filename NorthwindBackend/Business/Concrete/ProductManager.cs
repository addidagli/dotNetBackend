using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class userManager : IuserService
    {
        private IuserDal _userDal;

        public userManager(IuserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(user user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.userAdded);
        }

        public IResult Delete(user user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.userDeleted);
        }
        public IResult Update(user user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.userUpdated);
        }

        public IDataResult<user> GetById(int userId)
        {

            return new SuccessDataResult<user>(_userDal.Get(p => p.userId == userId));
        }

        public IDataResult<List<user>> GetList()
        {
            return new SuccessDataResult<List<user>>(_userDal.GetList().ToList());
        }

        public IDataResult<List<user>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<user>>(_userDal.GetList(p => p.CategoryId == categoryId).ToList());
        }


    }
}
