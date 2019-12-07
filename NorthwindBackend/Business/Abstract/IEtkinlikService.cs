using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEtkinlikService
    {
        IResult AddEtkinlik(Etkinlik etkinlik);
        IResult DeleteEtkinlik(Etkinlik etkinlik);
        IResult UpdateEtkinlik(Etkinlik etkinlik);

        IDataResult<List<Etkinlik>> GetAllEtkinlik();
        IDataResult<Etkinlik> GetEtkinlikById(int Id);
    }
}
