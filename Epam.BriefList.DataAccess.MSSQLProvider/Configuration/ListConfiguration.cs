using System.Data.Entity.ModelConfiguration;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Configuration
{
    public class ListConfiguration : EntityTypeConfiguration<OrmList>
    {
        public ListConfiguration()
        {
            ToTable("List");
            HasMany(e => e.OrmItems)
                .WithRequired(e => e.OrmList)
                .HasForeignKey(e => e.OrmListId);
        }
    }
}
