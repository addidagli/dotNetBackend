using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Etkinlik:IEntity
    {
        public int Id { get; set; }
        public string EtkinlikAdi { get; set; }

        public DateTime Tarih { get; set; }
        public DateTime BaslangicSaat { get; set; }

        public DateTime BitisSaat { get; set; }
        public string Aciklama { get; set; }
        public int OrganizasyonId { get; set; }
        public bool Aktif { get; set; }
        public bool Sil { get; set; }
        public string Yer { get; set; }
    }
}
