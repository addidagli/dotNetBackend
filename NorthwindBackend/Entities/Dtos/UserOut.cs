using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserOut
    {
        public int id { get; set; }
        public string adSoyad { get; set; }
        public string email { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public string telefon { get; set; }
        public DateTime tarih { get; set; }
        public int firmaId { get; set; }
    }
}
