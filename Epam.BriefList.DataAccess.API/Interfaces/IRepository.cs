using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Epam.BriefList.DataAccess.API.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        Task<T> Get(int id);
        T Get(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
