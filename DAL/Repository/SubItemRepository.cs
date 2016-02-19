using DAL.Infrastructure;
using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DALModels;
using DAL.Mapping;

namespace DAL.Repository
{
    public class SubItemRepository : RepositoryBase<OrmSubItem>, ISubItemRepository
    {
        public SubItemRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalSubItem entity)
        {
            throw new NotImplementedException();
        }

        public DalSubItem Get(Expression<Func<DalSubItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalSubItem> GetAll()
        {
            return DbSet.AsEnumerable().Select(Mapper.ToDalSubItem);
        }

        public DalSubItem Get(int id)
        {
            return Mapper.ToDalSubItem(DbSet.FirstOrDefault(t => t.Id == id));
        }

        public IEnumerable<DalSubItem> GetMany(Expression<Func<DalSubItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalSubItem entity)
        {
            DbSet.AddOrUpdate(Mapper.ToOrmSubItem(entity));
        }
    }
}
