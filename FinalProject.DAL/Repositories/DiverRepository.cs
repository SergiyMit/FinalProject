﻿using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.DAL.EF;
using FinalProject.DAL.Interfaces;

namespace FinalProject.DAL.Repositories
{
    class DiverRepository : IRepository<Diver>
    {
        private readonly NixDatabaseContext db;
        public DiverRepository(NixDatabaseContext context)
        {
            this.db = context;
        }
        public IEnumerable<Diver> GetAll()
        {
            return db.Divers;
        }

        public Diver Get(int id)
        {
            return db.Divers.Find(id);
        }
        public Diver GetByLogin(string login)
        {
            int idUser = (from user in db.Users where user.Login == login select user.IdUser).FirstOrDefault();
            Diver diver = (from d in db.Divers where d.IdUser == idUser select d).FirstOrDefault();
            return diver;
        }

        public void Create(Diver item)
        {
            db.Divers.Add(item);
            db.SaveChanges();
        }

        public void Update(Diver item)
        {
            db.Update(item);
            db.SaveChanges();
        }

        public IEnumerable<Diver> Find(Func<Diver, Boolean> predicate)
        {
            return db.Divers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Diver diver = db.Divers.Find(id);
            if (diver != null)
                db.Divers.Remove(diver);
        }

        public Diver GetId(string login)
        {
            throw new NotImplementedException();
        }
    }
}
