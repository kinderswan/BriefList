using System.Data.Entity.ModelConfiguration;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Configuration
{
    public class ItemConfiguration : EntityTypeConfiguration<OrmItem>
    {
        public ItemConfiguration()
        {
            ToTable("Item");
            HasMany(e => e.ItemFiles).WithRequired(e => e.OrmItem).HasForeignKey(e => e.OrmItemId);
            HasMany(e => e.Comments).WithRequired(e => e.OrmItem).HasForeignKey(e => e.OrmItemId);
            HasMany(e => e.SubItems).WithRequired(e => e.OrmItem).HasForeignKey(e => e.OrmItemId);
        }
    }
}
