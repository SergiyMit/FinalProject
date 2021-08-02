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
        IRepository<CertificateLevel> CertificateLevels { get; }
        IRepository<DiveCertificate> DiveCertificates { get; }
        IRepository<DiveMeasurement> DiveMeasurements { get; }
        void Save();
    }
}
