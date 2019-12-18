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

    ///select eklendi ..
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
            return new SuccessDataResult<List<Etkinlik>>(_etkinlikDal.GetList().ToList());
        }


        //Etkinliklerin idlerini çeker
        public IDataResult<List<int>> GetAllEtkinlikId()
        {
            return new SuccessDataResult<List<int>>(_etkinlikDal.GetList().Select(a => a.Id).ToList());
        }


        //etkinlikadına göre idleri çeker
        public IDataResult<int> GetAllEtkinlikIdWithName(string etkinlikAdi)
        {
            return new SuccessDataResult<int>(_etkinlikDal.Get(b => b.EtkinlikAdi == etkinlikAdi).Id);
        }
        public IDataResult<Etkinlik> GetEtkinlikById(int Id)
        {
            return new SuccessDataResult<Etkinlik>(_etkinlikDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<Etkinlik>> GetEtkinlikByEtkinlikIds(List<int> etkinlikIds)
        {
            return new SuccessDataResult<List<Etkinlik>>(_etkinlikDal.GetListFilter(p => etkinlikIds.Contains(p.Id)).ToList());
        }


    }
}
