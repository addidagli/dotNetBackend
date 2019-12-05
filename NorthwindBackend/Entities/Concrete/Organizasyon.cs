using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Organizasyon : IEntity
    {
        public int Id { get; set; }
        public string Aciklama { get; set; }
        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }
        public string Konum { get; set; }
        public string OrganizasyonAdi { get; set; }
        public int OrganizatorId { get; set; }
        public bool Aktif { get; set; }
        public bool Sil { get; set; }
        public string Tip { get; set; }
    }
}
