using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Infrastructure;
using ORM.ORMModels;
using DAL.Mapping;
using System.Data.Entity;
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

        public void Delete(Expression<Func<DalUserProfile, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalUserProfile entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public DalUserProfile GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUserProfile> GetMany(Expression<Func<DalUserProfile, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUserProfile entity)
        {
            throw new NotImplementedException();
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
