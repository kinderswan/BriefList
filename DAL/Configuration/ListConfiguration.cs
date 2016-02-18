using ORM.ORMModels;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
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
