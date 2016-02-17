using DAL.Infrastructure;
using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Mapping;
using System.Data.Entity;
using DAL.Interfaces.DALModels;
using DAL.Interfaces.Interfaces;

namespace DAL.Repository
{
    public class ItemFileRepository : RepositoryBase<OrmItemFile>, IItemFileRepository
    {
        public ItemFileRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalItemFile entity)
        {
            DbSet.Add(Mapper.ToOrmItemFile(entity));
        }

        public void Delete(Expression<Func<DalItemFile, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalItemFile entity)
        {
            throw new NotImplementedException();
        }

        public DalItemFile Get(Expression<Func<DalItemFile, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalItemFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalItemFile GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalItemFile> GetMany(Expression<Func<DalItemFile, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalItemFile entity)
        {
            throw new NotImplementedException();
        }
    }
}
