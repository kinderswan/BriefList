using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Configuration
{
    public class UserProfileConfiguration : EntityTypeConfiguration<OrmUserProfile>
    {
        public UserProfileConfiguration()
        {
            ToTable("UserProfile");
            HasMany(e => e.OrmLists)
                .WithRequired(e => e.OrmUserProfile)
                .HasForeignKey(e => e.OrmUserProfileId);
        }
    }
}
