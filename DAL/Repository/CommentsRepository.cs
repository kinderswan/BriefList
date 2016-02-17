using DAL.Infrastructure;
using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Mapping;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DALModels;

namespace DAL.Repository
{
    public class CommentsRepository : RepositoryBase<OrmComments>, ICommentsRepository
    {
        public CommentsRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalComments entity)
        {
            DbSet.Add(Mapper.ToOrmComments(entity));
        }

        public void Delete(Expression<Func<DalComments, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalComments entity)
        {
            DbSet.Remove(Mapper.ToOrmComments(entity));
        }

        public DalComments Get(Expression<Func<DalComments, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalComments> GetAll()
        {
            return DbSet.ToList().Select(e => Mapper.ToDalComments(e));
        }

        public DalComments GetById(int id)
        {
            return Mapper.ToDalComments(DbSet.Find(id));
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
