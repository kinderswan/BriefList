using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
