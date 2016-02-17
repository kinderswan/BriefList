using System.Data.Entity;

namespace DAL.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private readonly DbContext _dataContext;
        protected IDbSet<T> DbSet;
        #endregion

        protected RepositoryBase(DbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
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

        //public virtual void Delete(Expression<Func<T, bool>> where)
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
