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

        IResult AddUser(User user);
        IResult DeleteUser(User user);
        IResult UpdateUser(User user);

        IDataResult<List<User>> GetAllUser();
        IDataResult<User> GetUserById(int Id);
        /*IDataResult<List<User>> GetListUserByActivity(int activityId);
        IDataResult<List<User>> GetListUserByCompany(int companyId);
        IDataResult<List<User>> GetListOrganizatorByOrganization(int organizationId);*/

       
    }
}
