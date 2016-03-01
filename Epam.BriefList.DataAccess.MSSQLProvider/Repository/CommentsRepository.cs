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
    public class CommentsRepository : RepositoryBase<OrmComments>, ICommentsRepository
    {
        public CommentsRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalComments entity)
        {
            DbSet.Add(Mapper.ToOrmComments(entity));
        }
        public DalComments Get(Expression<Func<DalComments, bool>> where)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<DalComments>> GetAll() => await Task.Run(() => DbSet.ToList().Select(Mapper.ToDalComments));

        public async Task<DalComments> Get(int id)
        {
            return Mapper.ToDalComments(await DbSet.FirstOrDefaultAsync(t => t.Id == id));
        }
        public IEnumerable<DalComments> GetMany(Expression<Func<DalComments, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalComments entity)
        {
            DbSet.AddOrUpdate(Mapper.ToOrmComments(entity));
        }
    }
}
