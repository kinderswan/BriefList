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
    public class UserProfileRepository : RepositoryBase<OrmUserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext dbContext) : base(dbContext) { }
        public void Add(DalUserProfile entity) => DbSet.Add(Mapper.ToOrmUserProfile(entity));
        public void Update(DalUserProfile entity) => DbSet.AddOrUpdate(Mapper.ToOrmUserProfile(entity));

        public async Task<IEnumerable<DalUserProfile>> GetAll() => await Task.Run(() => DbSet.AsEnumerable().Select(Mapper.ToDalUserProfile));
        public async Task<DalUserProfile> Get(string name) => Mapper.ToDalUserProfile(await DbSet.FirstOrDefaultAsync(t => t.Name == name));
        public async Task<DalUserProfile> Get(int id) => Mapper.ToDalUserProfile(await DbSet.FirstOrDefaultAsync(t => t.Id == id));
        public async Task<bool> UserEmailExist(string email) => await DbSet.FirstOrDefaultAsync(dbuser => dbuser.Email.Equals(email)) != null;
        public async Task<bool> UserNameExist(string name) => await DbSet.FirstOrDefaultAsync(dbuser => dbuser.Name.Equals(name)) != null;



        public DalUserProfile Get(Expression<Func<DalUserProfile, bool>> where)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DalUserProfile> GetMany(Expression<Func<DalUserProfile, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
