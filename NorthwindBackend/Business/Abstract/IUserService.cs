using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IResult SendMail(string email);

        IResult UserExist(string email);
        IResult AddUser(User user);
        IResult DeleteUser(User user);
        IResult UpdateUser(User user, int firmaId);
        IDataResult<List<User>> GetAllUser();
        IDataResult<User> GetUserById(int Id);

        //IDataResult<List<User>> GetUserByEtkinlikId(int etkinlikId);

        //aynı tabloda bulunan bi değere göre liste çekmek için
        IDataResult<List<User>> GetUsersByUserIds(List<int> userIds);

        //IDataResult<List<User>> GetListOrganizatorByOrganization(int organizationId);


    }
}
