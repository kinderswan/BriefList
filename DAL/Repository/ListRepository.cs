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
    public class ListRepository : RepositoryBase<OrmList>, IListRepository
    {
        public ListRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalList entity)
        {
            throw new NotImplementedException();
        }

        public DalList Get(Expression<Func<DalList, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalList> GetAll()
        {
            return DbSet.AsEnumerable().Select(Mapper.ToDalList);
        }

        public async Task<DalList> Get(int id)
        {
            return Mapper.ToDalList(await DbSet.FirstOrDefaultAsync(t => t.Id == id));
        }

        public IEnumerable<DalList> GetMany(Expression<Func<DalList, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalList entity)
        {
            DbSet.AddOrUpdate(Mapper.ToOrmList(entity));
        }
    }
}
