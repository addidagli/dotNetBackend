using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEtkinlikFirmaDal :EfEntityRepositoryBase<EtkinlikFirma, NorthwindContext>, IEtkinlikFirmaDal
    {
        public List<EtkinlikFirma> GetEtkinlikFirma(Firma firma)
        {
            using (var context = new NorthwindContext())
            {
                var result = from etkinlik in context.TblEtkinlik
                             join etkinlikFirma in context.TblEtkinlikFirma
                             on etkinlik.Id equals etkinlikFirma.EtkinlikId
                             where etkinlikFirma.FirmaId == firma.Id
                             select new EtkinlikFirma { EtkinlikId = etkinlik.Id, FirmaId = firma.Id };
                return result.ToList();
            }
        }
    }
}
