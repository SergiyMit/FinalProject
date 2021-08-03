using FinalProject.DAL.EF;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.DAL.Repositories
{
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private readonly NixDatabaseContext db;
        private readonly DbSet<T> dbSet;
        public UserRepository(NixDatabaseContext context)
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

        public Diver GetDiverByLogin(string login)
        {
            User user = GetUserByLogin(login);
            int idUser = user.IdUser;
            Diver diver = (from d in db.Divers where d.IdUser == idUser select d).FirstOrDefault();
            return diver;
        }
        public User GetUserByLogin(string login)
        {
            var user = (from u in db.Users where u.Login == login select u).FirstOrDefault();
            return user;
        }
        public Admin GetAdminByLogin(string login)
        {
            User user = GetUserByLogin(login);
            int idUser = user.IdUser;
            Admin admin = (from d in db.Admins where d.IdUser == idUser select d).FirstOrDefault();
            return admin;
        }
        public int GetId(string login)
        {
            var user = GetUserByLogin(login);
            int idUser = user.IdUser;
            return idUser;
        }

        public void Update(T item)
        {
            dbSet.Update(item);
            db.SaveChanges();
        }
    }
}
