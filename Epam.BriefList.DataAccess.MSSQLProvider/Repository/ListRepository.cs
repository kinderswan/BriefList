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
    public class ListRepository : RepositoryBase<OrmList>, IListRepository
    {
        public ListRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<DalList>> GetAll() => await Task.Run(() => DbSet.AsEnumerable().Select(Mapper.ToDalList));
        public async Task<DalList> Get(int id) => Mapper.ToDalList(await DbSet.FirstOrDefaultAsync(t => t.Id == id));
        public void Update(DalList entity) => DbSet.AddOrUpdate(Mapper.ToOrmList(entity));
        public IEnumerable<DalList> GetAllListsNames() => DbSet.Select(dblist => new { Id = dblist.Id, Title = dblist.Title }).AsEnumerable().Select(lt => new OrmList { Title = lt.Title, Id = lt.Id }).Select(Mapper.ToDalList);
        public async Task<IEnumerable<DalList>> GetByOwnerId(int id) => await Task.Run(() => DbSet.Where(db=>db.OwnerId==id).AsEnumerable().Select(Mapper.ToDalList));

        public void Add(DalList entity) => DbSet.Add(Mapper.ToOrmList(entity));



        public DalList Get(Expression<Func<DalList, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalList> GetMany(Expression<Func<DalList, bool>> where)
        {
            throw new NotImplementedException();
        }

    }
}
