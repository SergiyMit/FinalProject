using FinalProject.DAL.Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.DAL.EF;
using FinalProject.DAL.Interfaces;

namespace FinalProject.DAL.Repositories
{
    class CertificateLevelRepository : IRepository<CertificateLevel>
    {
        private readonly NixDatabaseContext db;
        public CertificateLevelRepository(NixDatabaseContext context)
        {
            this.db = context;
        }
        public IEnumerable<CertificateLevel> GetAll()
        {
            return db.CertificateLevels;
        }

        public CertificateLevel Get(int id)
        {
            return db.CertificateLevels.Find(id);
        }

        public void Create(CertificateLevel item)
        {
            db.CertificateLevels.Add(item);
        }

        public void Update(CertificateLevel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<CertificateLevel> Find(Func<CertificateLevel, Boolean> predicate)
        {
            return db.CertificateLevels.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            CertificateLevel certificateLevel = db.CertificateLevels.Find(id);
            if (certificateLevel != null)
                db.CertificateLevels.Remove(certificateLevel);
        }
    }
}
