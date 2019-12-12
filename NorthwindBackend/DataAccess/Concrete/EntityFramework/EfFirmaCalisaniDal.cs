using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFirmaCalisaniDal : EfEntityRepositoryBase<FirmaCalisani, NorthwindContext>, IFirmaCalisaniDal
    {
        public List<User> GetFirmaCalisani(int firmaId)
        {
            using (var context = new NorthwindContext())
            {
                var result = from kullanici in context.TblKullanici
                             join firmaCalisani in context.TblFirmaCalisani
                             on firmaId equals firmaCalisani.FirmaId
                             where firmaCalisani.KullaniciId == kullanici.Id
                             select new User { Id = kullanici.Id, KullaniciAdi = kullanici.KullaniciAdi };
                return result.ToList();
            }
        }
    }
}
