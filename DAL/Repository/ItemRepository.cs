using DAL.Infrastructure;
using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DALModels;
using DAL.Mapping;

namespace DAL.Repository
{
    public class ItemRepository : RepositoryBase<OrmItem>, IItemRepository
    {
        public ItemRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalItem entity)
        {
            DbSet.Add(Mapper.ToOrmItem(entity));
        }

        public DalItem Get(Expression<Func<DalItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalItem> GetAll()
        {
            return DbSet.ToList().Select(Mapper.ToDalItem);
        }

        public async Task<DalItem> Get(int id)
        {
            return Mapper.ToDalItem(await DbSet.FirstOrDefaultAsync(t => t.Id == id));
        }
        public IEnumerable<DalItem> GetMany(Expression<Func<DalItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalItem entity)
        {
            DbSet.AddOrUpdate(Mapper.ToOrmItem(entity));
        }
    }
}
