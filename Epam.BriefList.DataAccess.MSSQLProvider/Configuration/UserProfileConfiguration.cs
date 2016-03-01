using System.Data.Entity.ModelConfiguration;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Configuration
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
