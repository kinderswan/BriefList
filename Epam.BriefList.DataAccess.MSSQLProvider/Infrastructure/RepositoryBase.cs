using System.Data.Entity;
using System.Linq;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class, IOrmEntity
    {
        #region Properties
        protected IDbSet<T> DbSet;
        #endregion

        protected RepositoryBase(DbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
        }
        public virtual void Delete(int id)
        {
            DbSet.Remove(DbSet.FirstOrDefault(t => t.Id == id));
        }

        //#region Implementation
        //public virtual void Add(T entity)
        //{
        //    _dbSet.Add(entity);
        //}

        //public virtual void Update(T entity)
        //{
        //    _dbSet.AddOrUpdate(entity);
        //}

        //public virtual void Delete(T entity)
        //{
        //    _dbSet.Remove(entity);
        //}

        //public virtual void DeleteById(Expression<Func<T, bool>> where)
        //{
        //    IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
        //    foreach (T obj in objects)
        //        _dbSet.Remove(obj);
        //}

        //public virtual T GetById(int id)
        //{
        //    return _dbSet.Find(id);
        //}

        //public virtual IEnumerable<T> GetAll()
        //{
        //    return _dbSet.ToList();
        //}

        //public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        //{
        //    return _dbSet.Where(where).ToList();
        //}

        //public T Get(Expression<Func<T, bool>> where)
        //{
        //    return _dbSet.Where(where).FirstOrDefault<T>();
        //}

        //#endregion

    }
}
