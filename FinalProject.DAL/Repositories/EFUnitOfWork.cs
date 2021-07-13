using FinalProject.DAL.EF;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using System;

namespace FinalProject.DAL.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private NixDatabaseContext db;
        private AdminRepository adminRepository;
        private CertificateLevelRepository certificateLevelRepository;
        private DiveCertificateRepository diveCertificateRepository;
        private DiveMeasurementRepository diveMeasurementRepository;
        private DiverRepository diverRepository;
        private UserRepository userRepository;
        public EFUnitOfWork(string connectionString)
        {
            db = new NixDatabaseContext(connectionString);
        }
        public IRepository<Admin> Admins
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(db);
                return adminRepository;
            }
        }

        public IRepository<CertificateLevel> CertificateLevels
        {
            get
            {
                if (certificateLevelRepository == null)
                    certificateLevelRepository = new CertificateLevelRepository(db);
                return certificateLevelRepository;
            }
        }
        public IRepository<DiveCertificate> DiveCertificates
        {
            get
            {
                if (diveCertificateRepository == null)
                    diveCertificateRepository = new DiveCertificateRepository(db);
                return diveCertificateRepository;
            }
        }

        public IRepository<DiveMeasurement> DiveMeasurements
        {
            get
            {
                if (diveMeasurementRepository == null)
                    diveMeasurementRepository = new DiveMeasurementRepository(db);
                return diveMeasurementRepository;
            }
        }
        public IRepository<Diver> Divers
        {
            get
            {
                if (diverRepository == null)
                    diverRepository = new DiverRepository(db);
                return diverRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

