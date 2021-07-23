using FinalProject.DAL.Entities;
using System;
using Microsoft.EntityFrameworkCore;
    namespace FinalProject.DAL.EF
{
    public partial class NixDatabaseContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CertificateLevel> CertificateLevels { get; set; }
        public DbSet<DiveCertificate> DiveCertificates { get; set; }
        public DbSet<DiveMeasurement> DiveMeasurements { get; set; }
        public DbSet<Diver> Divers { get; set; }
        public DbSet<User> Users { get; set; }
        public NixDatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MUQMAF1\\MITRIAIEV;Database=NixDatabase;Trusted_Connection=True;");
        }
    }
}

