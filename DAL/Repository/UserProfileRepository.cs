using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Infrastructure;
using ORM.ORMModels;
using DAL.Mapping;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DALModels;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DAL.Repository
{
    public class UserProfileRepository : RepositoryBase<OrmUserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext dbContext) : base(dbContext) { }

        public void Add(DalUserProfile entity)
        {
           DbSet.Add(Mapper.ToOrmUserProfile(entity));
        }

        public Task<DalUserProfile> Get(string name)
        {
            throw new NotImplementedException();
        }

        public DalUserProfile Get(Expression<Func<DalUserProfile, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUserProfile> GetAll()
        {
            return DbSet.AsEnumerable().Select(Mapper.ToDalUserProfile);
        }

        public DalUserProfile Get(int id)
        {
            return Mapper.ToDalUserProfile(DbSet.FirstOrDefault(t => t.Id == id));
        }

        public IEnumerable<DalUserProfile> GetMany(Expression<Func<DalUserProfile, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUserProfile entity)
        {
            DbSet.AddOrUpdate(Mapper.ToOrmUserProfile(entity));
        }

        public async Task<bool> UserEmailExist(string email)
        {
             return await DbSet.FirstOrDefaultAsync(dbuser => dbuser.Email.Equals(email)) != null;
        }

        public async Task<bool> UserNameExist(string name)
        {
            return await DbSet.FirstOrDefaultAsync(dbuser => dbuser.Name.Equals(name)) != null;
        }

    }
}
