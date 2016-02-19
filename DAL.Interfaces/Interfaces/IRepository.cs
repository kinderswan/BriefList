using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interfaces.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T Get(int id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
