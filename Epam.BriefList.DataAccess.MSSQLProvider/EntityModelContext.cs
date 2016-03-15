using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Epam.BriefList.DataAccess.MSSQLProvider.Configuration;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider
{
    public partial class EntityModelContext : DbContext
    {
        static EntityModelContext()
        {
            Database.SetInitializer(new BriefListSeed());
        }

        public EntityModelContext() : base("EntityModelContext")
        {
            Debug.WriteLine("Context creating!");
        }   

        public virtual DbSet<OrmUserProfile> OrmUserProfiles { get; set; }
        public virtual DbSet<OrmList> OrmLists { get; set; }
        public virtual DbSet<OrmItem> OrmItems { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
            modelBuilder.Configurations.Add(new ListConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
          
        }

    }
}
