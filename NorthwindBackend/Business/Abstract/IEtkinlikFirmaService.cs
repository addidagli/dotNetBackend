using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEtkinlikFirmaService
    {
        List<EtkinlikFirma> GetEtkinlikFirma(Firma firma);
        IResult AddEtkinlikFirma(EtkinlikFirma etkinlikFirma);

        IDataResult<List<int>> GetEtkinlikIdsByFirmaId(int etkinlikId);
    }
}
