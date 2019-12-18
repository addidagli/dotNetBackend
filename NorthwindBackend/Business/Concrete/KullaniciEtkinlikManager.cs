using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class KullaniciEtkinlikManager: IKullaniciEtkinlikService
    {
        IKullaniciEtkinlikDal _kullaniciEtkinlikDal;

        public KullaniciEtkinlikManager(IKullaniciEtkinlikDal kullaniciEtkinlikDal)
        {
            _kullaniciEtkinlikDal = kullaniciEtkinlikDal;
        }

        public IResult AddKullaniciEtkinlik(KullaniciEtkinlik kullaniciEtkinlik)
        {
            _kullaniciEtkinlikDal.Add(kullaniciEtkinlik);
            return new SuccessResult(Messages.EtkinlikAdded);
        }

        public IDataResult<List<int>> GetUserIdsByEtkinlikId(int etkinlikId)
        {
            return new SuccessDataResult<List<int>>(_kullaniciEtkinlikDal.GetListFilter(a => a.EtkinlikId == etkinlikId).Select(b => b.KullaniciId).ToList());

        }
    }
}
