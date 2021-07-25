using FinalProject.DAL.EF;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FinalProject.DAL.Repositories
{
    class AdminRepository : IRepository<Admin>
    {
        private readonly NixDatabaseContext db;
        public AdminRepository(NixDatabaseContext context)
        {
            this.db = context;
        }
        public IEnumerable<Admin> GetAll()
        {
            return db.Admins;
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }
        public Admin GetId(string login)
        {
            return db.Admins.Find(login);
        }
        public void Create(Admin item)
        {
            db.Admins.Add(item);
            db.SaveChanges();
        }

        public void Update(Admin item)
        {
            db.Update(item);
        }

        public IEnumerable<Admin> Find(Func<Admin, Boolean> predicate)
        {
            return db.Admins.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin != null)
                db.Admins.Remove(admin);
        }

        public Admin GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
