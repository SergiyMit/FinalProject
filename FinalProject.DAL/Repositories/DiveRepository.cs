using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.DAL.EF;
using FinalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DAL.Repositories
{
    class DiveRepository<T> : IDiveRepository<T> where T: class
    {
        private readonly NixDatabaseContext db;
        private readonly DbSet<T> dbSet;
        public DiveRepository(NixDatabaseContext context)
        {
            this.db = context;
            dbSet = context.Set<T>();
        }
        public void Create(T item)
        {
            dbSet.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public void Update(T item)
        {
            dbSet.Update(item);
            db.SaveChanges();
        }
    }
}
