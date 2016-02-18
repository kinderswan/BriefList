using DAL.Interfaces.Interfaces;
using System.Data.Entity;

namespace DAL.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
