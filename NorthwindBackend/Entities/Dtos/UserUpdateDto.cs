using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string KullaniciAdi { get; set; }
        public string Telefon { get; set; }
        public bool Aktif { get; set; }
        public string Sehir { get; set; }
        public bool IsAdmin { get; set; }
        public int fid { get; set; }
        public string Sifre { get; set; }
    }
}
