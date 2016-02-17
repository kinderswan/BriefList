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
    public class ListRepository : RepositoryBase<OrmList>, IListRepository
    {
        public ListRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalList entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<DalList, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalList entity)
        {
            throw new NotImplementedException();
        }

        public DalList Get(Expression<Func<DalList, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalList> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalList GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalList> GetMany(Expression<Func<DalList, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalList entity)
        {
            throw new NotImplementedException();
        }
    }
}
