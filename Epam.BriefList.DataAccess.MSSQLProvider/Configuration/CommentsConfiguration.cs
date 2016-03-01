using System.Data.Entity.ModelConfiguration;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Configuration
{
    public class CommentsConfiguration : EntityTypeConfiguration<OrmComments>
    {
        public CommentsConfiguration()
        {
            ToTable("Comments");
        }
    }
}
