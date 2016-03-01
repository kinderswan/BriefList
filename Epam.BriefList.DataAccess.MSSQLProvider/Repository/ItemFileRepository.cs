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

        public async Task<IEnumerable<DalItemFile>> GetAll() => await Task.Run(() => DbSet.ToList().Select(Mapper.ToDalItemFile));

        public async Task<DalItemFile> Get(int id)
        {
            return Mapper.ToDalItemFile(await DbSet.FirstOrDefaultAsync(t => t.Id == id));
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
