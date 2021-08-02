using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;


namespace FinalProject.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        User GetUserByLogin(string login);
        Diver GetDiverByLogin(string login);
        Admin GetAdminByLogin(string login);
        int GetId(string login); 
    }
}
