using ORM.ORMModels;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
{
    public class UserProfileConfiguration : EntityTypeConfiguration<OrmUserProfile>
    {
        public UserProfileConfiguration()
        {
            ToTable("UserProfile");

            HasMany(e => e.OrmLists)
            .WithMany(e => e.OrmUserProfiles)
            .Map(m => m.ToTable("UserProfileList")
                .MapLeftKey("OrmUserProfileId")
                .MapRightKey("OrmListId"));
        }
    }
}
