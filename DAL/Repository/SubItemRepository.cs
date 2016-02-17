using DAL.Infrastructure;
using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;
using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DALModels;

namespace DAL.Repository
{
    public class SubItemRepository : RepositoryBase<OrmSubItem>, ISubItemRepository
    {
        public SubItemRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalSubItem entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<DalSubItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalSubItem entity)
        {
            throw new NotImplementedException();
        }

        public DalSubItem Get(Expression<Func<DalSubItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalSubItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalSubItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalSubItem> GetMany(Expression<Func<DalSubItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalSubItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
