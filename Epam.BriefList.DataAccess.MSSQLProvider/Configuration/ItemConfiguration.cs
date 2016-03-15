using System.Data.Entity.ModelConfiguration;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Configuration
{
    public class ItemConfiguration : EntityTypeConfiguration<OrmItem>
    {
        public ItemConfiguration()
        {
            ToTable("Item");
        }
    }
}
