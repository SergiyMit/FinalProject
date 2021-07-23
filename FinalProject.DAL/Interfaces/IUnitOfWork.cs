using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Admin> Admins { get; }
        IRepository<CertificateLevel> CertificateLevels { get; }
        IRepository<DiveCertificate> DiveCertificates { get; }
        IRepository<DiveMeasurement> DiveMeasurements { get; }
        IRepository<Diver> Divers { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
