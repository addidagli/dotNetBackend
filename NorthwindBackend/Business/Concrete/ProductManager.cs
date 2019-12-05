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
    public class productManager : IProductService
    {
        private IProductDal _productDal;

        public productManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.userAdded);
        }

        public IResult Delete(Product user)
        {
            _productDal.Delete(user);
            return new SuccessResult(Messages.userDeleted);
        }
        public IResult Update(Product user)
        {
            _productDal.Update(user);
            return new SuccessResult(Messages.userUpdated);
        }

        public IDataResult<product> GetById(int userId)
        {

            return new SuccessDataResult<product>(_productDal.Get(p => p.userId == userId));
        }

        public IDataResult<List<product>> GetList()
        {
            return new SuccessDataResult<List<product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }


    }
}
