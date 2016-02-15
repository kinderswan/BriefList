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
        public EntityModelContext() : base("name=EntityModelContext")
        {
            Debug.WriteLine("Context creating!");
        }
        public virtual DbSet<OrmUserProfile> OrmCathegories { get; set; }
        public virtual DbSet<OrmList> OrmLots { get; set; }
        public virtual DbSet<OrmItem> OrmRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<OrmUserProfile>()
                .HasMany(e => e.OrmLists)
                .WithRequired(e => e.OrmUserProfile)
                .HasForeignKey(e => e.OrmUserProfileId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrmList>()
                .HasMany(e => e.OrmItems)
                .WithRequired(e => e.OrmList)
                .HasForeignKey(e => e.OrmListId)
                .WillCascadeOnDelete(false);

        }
        public void Dispose()
        {
            base.Dispose();
            Debug.WriteLine("Context disposing!");
        }

    }
}
