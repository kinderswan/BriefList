
using DAL.Configuration;
using ORM.ORMModels;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace DAL
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
        public virtual DbSet<OrmComments> OrmComments { get; set; }
        public virtual DbSet<OrmItemFile> OrmItemFiles { get; set; }
        public virtual DbSet<OrmSubItem> OrmSubItems { get; set; }

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

    }
}
