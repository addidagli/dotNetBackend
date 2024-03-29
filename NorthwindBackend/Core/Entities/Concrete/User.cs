﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        [Required]
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string KullaniciAdi { get; set; }
        public string Telefon { get; set; }
        public DateTime Tarih { get; set; }

        public bool Aktif { get; set; }
        public bool Sil { get; set; }

        public string Qrkod { get; set; }
        public string Barkod { get; set; }

        public string Sehir { get; set; }
        public bool IsAdmin { get; set; }
        public int fid { get; set; }
        public byte[] SifreCoz { get; set; }
        public byte[] Sifrele { get; set; }

        /*public User()
        {
            this.Aktif = true;
            this.Sil = false;
            this.Qrkod = "";
            this.Barkod = "";
            this.Sehir = "";
            this.IsAdmin = false;
        }*/


    }
}
