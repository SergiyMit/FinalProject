using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.DAL.EF;
using FinalProject.DAL.Interfaces;

namespace FinalProject.DAL.Repositories
{
    class UserRepository : IRepository<User>
    {
        private NixDatabaseContext db;
        public UserRepository(NixDatabaseContext context)
        {
            this.db = context;
        }
        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public User GetId(string login)
        {
            var user = db.Users.Where(u => u.Login == login).FirstOrDefault();
            return user;
        }
        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Update(User item)
        {
            db.Update(item);
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public User GetByLogin(string login)
        {
            var user = (from u in db.Users where u.Login == login select u).FirstOrDefault();
            return user;
        }
    }
}
