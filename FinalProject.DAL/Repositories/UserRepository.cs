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
    class UserRepository : IRepository<User>
    {
        private readonly NixDatabaseContext db;
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
            return db.Users.Find(login);
        }
        public void Create(User item)
        {
            db.Users.Add(item);
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
    }
}
