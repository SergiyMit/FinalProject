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
    class DiveCertificateRepository : IRepository<DiveCertificate>
    {
        private readonly NixDatabaseContext db;
        public DiveCertificateRepository(NixDatabaseContext context)
        {
            this.db = context;
        }
        public IEnumerable<DiveCertificate> GetAll()
        {
            return db.DiveCertificates;
        }

        public DiveCertificate Get(int id)
        {
            return db.DiveCertificates.Find(id);
        }
        public DiveCertificate GetId(string number)
        {
            return db.DiveCertificates.Find(number);
        }
        public void Create(DiveCertificate item)
        {
            db.DiveCertificates.Add(item);
            db.SaveChanges();
        }

        public void Update(DiveCertificate item)
        {
            db.Update(item);
        }

        public IEnumerable<DiveCertificate> Find(Func<DiveCertificate, Boolean> predicate)
        {
            return db.DiveCertificates.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            DiveCertificate diveCertificate = db.DiveCertificates.Find(id);
            if (diveCertificate != null)
                db.DiveCertificates.Remove(diveCertificate);
        }

        public DiveCertificate GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
