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
    public class ItemRepository : RepositoryBase<OrmItem>, IItemRepository
    {
        public ItemRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalItem entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<DalItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalItem entity)
        {
            throw new NotImplementedException();
        }

        public DalItem Get(Expression<Func<DalItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalItem> GetMany(Expression<Func<DalItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
