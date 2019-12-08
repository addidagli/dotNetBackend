using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class EtkinlikManager:IEtkinlikService
    {
        IEtkinlikDal _etkinlikDal;

        public EtkinlikManager(IEtkinlikDal etkinlikDal)
        {
            _etkinlikDal = etkinlikDal;
        }

        public IResult AddEtkinlik(Etkinlik etkinlik)
        {
            _etkinlikDal.Add(etkinlik);
            _etkinlikDal.AddEtkinlik(etkinlik);
            return new SuccessResult(Messages.EtkinlikAdded);
        }
        public IResult UpdateEtkinlik(Etkinlik etkinlik)
        {
            _etkinlikDal.Update(etkinlik);
            return new SuccessResult(Messages.EtkinlikUpdated);
        }

        public IResult DeleteEtkinlik(Etkinlik etkinlik)
        {
            _etkinlikDal.Delete(etkinlik);
            return new SuccessResult(Messages.EtkinlikDeleted);
        }

        public IDataResult<List<Etkinlik>> GetAllEtkinlik()
        {
            //return new SuccessDataResult<List<Etkinlik>>(_etkinlikDal.GetList(p => p.Id < 10).ToList());
            return new SuccessDataResult<List<Etkinlik>>(_etkinlikDal.GetList().ToList());
        }

        public IDataResult<Etkinlik> GetEtkinlikById(int Id)
        {
            return new SuccessDataResult<Etkinlik>(_etkinlikDal.Get(p => p.Id == Id));
        }

        
    }
}
