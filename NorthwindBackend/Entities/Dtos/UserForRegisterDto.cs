using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserForRegisterDto:IDto
    {
            public string Email { get; set; }
            public string Sifre { get; set; }
            public string AdSoyad { get; set; }
            public string Telefon { get; set; }
            public string KullaniciAdi { get; set; }
            public bool Admin { get; set; }
   
            public string Sehir { get; set; }
        
    }
}
