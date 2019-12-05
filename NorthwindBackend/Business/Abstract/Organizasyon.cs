using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface Organizasyon
    {
        IResult AddOrganizasyon(Organizasyon user);
        IResult DeleteOrganizasyon(Organizasyon user);
        IResult UpdateOrganizasyon(Organizasyon user);

        IDataResult<List<Organizasyon>> GetAllOrganizasyon();
        IDataResult<Organizasyon> GetOrganizasyonById(int Id);
    }
}
