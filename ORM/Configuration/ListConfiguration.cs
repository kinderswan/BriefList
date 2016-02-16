using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Configuration
{
    public class ListConfiguration : EntityTypeConfiguration<OrmList>
    {
        public ListConfiguration()
        {
            ToTable("List");
            HasMany(e => e.OrmItems)
                .WithRequired(e => e.OrmList)
                .HasForeignKey(e => e.OrmListId)
                .WillCascadeOnDelete(false);
        }
    }
}
