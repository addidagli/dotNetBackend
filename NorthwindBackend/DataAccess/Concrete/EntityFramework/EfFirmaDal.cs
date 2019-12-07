using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFirmaDal : EfEntityRepositoryBase<Firma, NorthwindContext>, IFirmaDal
    {
     
        List<Etkinlik> IFirmaDal.GetEtkinlik(Firma firma)
        {
            using (var context = new NorthwindContext())
            {
                var result = from etkinlik in context.TblEtkinlik
                             join etkinlikfirma in context.TblEtkinlikFirma
                             on etkinlik.Id equals etkinlikfirma.EtkinlikId
                             where etkinlikfirma.FirmaId == firma.Id
                             select new Etkinlik { Id = etkinlik.Id, EtkinlikAdi = etkinlik.EtkinlikAdi };
                return result.ToList();
            }
        }
    }
}
