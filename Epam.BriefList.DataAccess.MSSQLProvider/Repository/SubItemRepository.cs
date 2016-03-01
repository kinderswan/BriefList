using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Epam.BriefList.DataAccess.API.Interfaces;
using Epam.BriefList.DataAccess.API.Models;
using Epam.BriefList.DataAccess.MSSQLProvider.Infrastructure;
using Epam.BriefList.DataAccess.MSSQLProvider.Mapping;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Repository
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
