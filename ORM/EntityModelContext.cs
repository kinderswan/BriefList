using ORM.Configuration;
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

        public virtual DbSet<OrmUserProfile> OrmCathegories { get; set; }
        public virtual DbSet<OrmList> OrmLots { get; set; }
        public virtual DbSet<OrmItem> OrmRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
            modelBuilder.Configurations.Add(new ListConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
        }
        public void Dispose()
        {
            base.Dispose();
            Debug.WriteLine("Context disposing!");
        }

    }
}
