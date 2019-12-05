using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IuserService
    {
        IDataResult<user> GetById(int userId);
        IDataResult<List<user>> GetList();
        IDataResult<List<user>> GetListByCategory(int categoryId);

        IResult Add(user user);
        IResult Delete(user user);
        IResult Update(user user);


    }
}
