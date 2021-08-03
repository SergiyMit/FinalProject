using System;
using System.Collections.Generic;

namespace FinalProject.DAL.Interfaces
{
    public interface IDiveRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
