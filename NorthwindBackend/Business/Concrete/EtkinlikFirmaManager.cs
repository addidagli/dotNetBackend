using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EtkinlikFirmaManager:IEtkinlikFirmaService
    {
        IEtkinlikFirmaDal _etkinlikFirmaDal;

        public EtkinlikFirmaManager(IEtkinlikFirmaDal etkinlikFirmaDal)
        {
            _etkinlikFirmaDal = etkinlikFirmaDal;
        }

        public IResult AddEtkinlikFirma(EtkinlikFirma etkinlikFirma)
        {
            _etkinlikFirmaDal.Add(etkinlikFirma);
            return new SuccessResult(Messages.EtkinlikAdded);
        }

        public List<EtkinlikFirma> GetEtkinlikFirma(Firma firma)
        {
            return _etkinlikFirmaDal.GetEtkinlikFirma(firma);
        }
    }
}
