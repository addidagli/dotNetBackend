using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=EysDeneme;Username=postgres;Password=addi1903");
        }

        
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        
        public DbSet<User> TblKullanici { get; set; }
        public DbSet<Organizasyon> TblOrganizasyon { get; set; }
        public DbSet<Etkinlik> TblEtkinlik { get; set; }
        public DbSet<Firma> TblFirma { get; set; }
        public DbSet<EtkinlikFirma> TblEtkinlikFirma { get; set; }
        public DbSet<FirmaCalisani> TblFirmaCalisani { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}