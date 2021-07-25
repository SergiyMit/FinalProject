﻿using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T GetByLogin(string login);
        T GetId(string login);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
