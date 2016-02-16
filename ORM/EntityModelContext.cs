using ORM.Configuration;
using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class EntityModelContext : DbContext
    {
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
            modelBuilder.Configurations.Add(new ItemFileConfiguration());
            modelBuilder.Configurations.Add(new CommentsConfiguration());
            modelBuilder.Configurations.Add(new SubItemConfiguration());
        }
        public void Dispose()
        {
            base.Dispose();
            Debug.WriteLine("Context disposing!");
        }

    }
}
