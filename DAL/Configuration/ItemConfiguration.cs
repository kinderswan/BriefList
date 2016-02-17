using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class ItemConfiguration : EntityTypeConfiguration<OrmItem>
    {
        public ItemConfiguration()
        {
            ToTable("Item");
            HasMany(e => e.ItemFiles).WithRequired(e => e.OrmItem).HasForeignKey(e => e.OrmItemID);
            HasMany(e => e.Comments).WithRequired(e => e.OrmItem).HasForeignKey(e => e.OrmItemID);
            HasMany(e => e.SubItems).WithRequired(e => e.OrmItem).HasForeignKey(e => e.OrmItemID);
        }
    }
}
