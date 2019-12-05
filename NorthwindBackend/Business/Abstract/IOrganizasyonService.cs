using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrganizasyonService
    {
        IResult AddOrganizasyon(Organizasyon organizasyon);
        IResult DeleteOrganizasyon(Organizasyon organizasyon);
        IResult UpdateOrganizasyon(Organizasyon organizasyon);

        IDataResult<List<Organizasyon>> GetAllOrganizasyon();
        IDataResult<Organizasyon> GetOrganizasyonById(int Id);
    }
}
