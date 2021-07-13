using FinalProject.DAL.Entities;
using System;
using System.Data.Entity;
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

        static NixDatabaseContext()
        {
            Database.SetInitializer<NixDatabaseContext>(new DiveDBInitializer());
        }
        public NixDatabaseContext(string connectionString)
            : base(connectionString)
        {
        }
        public class DiveDBInitializer : DropCreateDatabaseIfModelChanges<NixDatabaseContext>
        {
            protected override void Seed(NixDatabaseContext db)
            {
                db.Admins.Add(new Admin {Name = "Admin1", Surname = "AdminSurname1", PersonalAccessCode = 123456,  User = new User { Login = "Adminr1Login", Password = "123456", UserType = 0 }});
                db.Divers.Add(new Diver {Name = "Diver1", Surname = "Diver1Surname", Age = 27, Email = "diver1@mail.com", TelNumber = 676443637, DeviceNumber = 1, User = new User {Login = "Diver1Login", Password = "123456", UserType = 1 } });
                db.SaveChanges();
            }
        }
    }
}

