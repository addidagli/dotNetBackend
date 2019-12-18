using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class KullaniciEtkinlik:IEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int EtkinlikId { get; set; }
    }
}
