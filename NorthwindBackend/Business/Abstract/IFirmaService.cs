using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFirmaService
    {
        IResult AddFirma(Firma firma);
        IResult DeleteFirma(Firma firma);
        IResult UpdateFirma(Firma firma);

        IDataResult<List<Firma>> GetAllFirma();
        IDataResult<Firma> GetFirmaById(int Id);

        List<Etkinlik> GetEtkinlik(Firma firma);
    }
}
