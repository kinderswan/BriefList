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

        public async Task<IEnumerable<DalItem>> GetAll() => await Task.Run(() => DbSet.ToList().Select(Mapper.ToDalItem));

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
