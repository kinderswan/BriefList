using System.Data.Entity.ModelConfiguration;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Configuration
{
    public class ItemFileConfiguration : EntityTypeConfiguration<OrmItemFile>
    {
        public ItemFileConfiguration()
        {
            ToTable("ItemFile");
        }
    }
}
