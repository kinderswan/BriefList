using DAL.Infrastructure;
using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Mapping;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
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

        public DalItemFile Get(Expression<Func<DalItemFile, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalItemFile> GetAll()
        {
            return DbSet.ToList().Select(Mapper.ToDalItemFile);
        }

        public DalItemFile Get(int id)
        {
            return Mapper.ToDalItemFile(DbSet.FirstOrDefault(t => t.Id == id));
        }

        public IEnumerable<DalItemFile> GetMany(Expression<Func<DalItemFile, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalItemFile entity)
        {
            DbSet.AddOrUpdate(Mapper.ToOrmItemFile(entity));
        }
    }
}
