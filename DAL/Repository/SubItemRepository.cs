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
    public class SubItemRepository : RepositoryBase<OrmSubItem>, ISubItemRepository
    {
        public SubItemRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalSubItem entity) => DbSet.Add(Mapper.ToOrmSubItem(entity));

        public DalSubItem Get(Expression<Func<DalSubItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DalSubItem>> GetAll() => await Task.Run(() => DbSet.AsEnumerable().Select(Mapper.ToDalSubItem));

        public async Task<DalSubItem> Get(int id) => Mapper.ToDalSubItem(await DbSet.FirstOrDefaultAsync(t => t.Id == id));

        public IEnumerable<DalSubItem> GetMany(Expression<Func<DalSubItem, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalSubItem entity) => DbSet.AddOrUpdate(Mapper.ToOrmSubItem(entity));
    }
}
