using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.DataAccess.Interfaces
{
    interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
