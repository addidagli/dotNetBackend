using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Firma : IEntity
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }
        public string SirketAdi { get; set; }
        public int MersisNo { get; set; }
        public int VergiNo { get; set; }
        public int YetkiliKisiId { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public bool Aktif { get; set; }
        public bool Sil { get; set; }

        public int MasaNo { get; set; }
        public int RfId { get; set; }
        public int EtkinlikId { get; set; }
        public string Hizmetler { get; set; }
        public int UrunGruplari { get; set; }
        public string Temsilcilikler { get; set; }
        public string Sifre { get; set; }
    }
}
