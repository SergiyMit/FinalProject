using FinalProject.DAL.EF;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using System;

namespace FinalProject.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly NixDatabaseContext db;
        private CertificateLevelRepository certificateLevelRepository;
        private DiveCertificateRepository diveCertificateRepository;
        private DiveMeasurementRepository diveMeasurementRepository;
        public EFUnitOfWork()
        {
            db = new NixDatabaseContext();
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

