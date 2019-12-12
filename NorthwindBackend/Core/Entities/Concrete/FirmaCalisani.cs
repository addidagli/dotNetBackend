using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class FirmaCalisani:IEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int? FirmaId { get; set; }
        public bool IsDelege { get; set; }

    }
}
