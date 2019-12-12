using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class FirmaManager:IFirmaService
    {
        
        IFirmaDal _firmaDal;

        public FirmaManager(IFirmaDal firmaDal)
        {
            _firmaDal = firmaDal;
        }

        public IResult AddFirma(Firma firma)
        {
            _firmaDal.Add(firma);
            return new SuccessResult(Messages.FirmaAdded);
        }

        public IResult UpdateFirma(Firma firma)
        {
            _firmaDal.Update(firma);
            return new SuccessResult(Messages.FirmaUpdated);
        }

        public IResult DeleteFirma(Firma firma)
        {
            _firmaDal.Delete(firma);
            return new SuccessResult(Messages.FirmaDeleted);
        }

        public IDataResult<List<Firma>> GetAllFirma()
        {
            return new SuccessDataResult<List<Firma>>(_firmaDal.GetList().ToList());
        }

        public IDataResult<Firma> GetFirmaById(int Id)
        {
            return new SuccessDataResult<Firma>(_firmaDal.Get(p => p.Id == Id));
        }

        public List<Etkinlik> GetEtkinlik(Firma firma)
        {
            return _firmaDal.GetEtkinlik(firma);
        }

      
    }
}
