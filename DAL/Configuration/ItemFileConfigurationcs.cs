using ORM.ORMModels;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
{
    public class ItemFileConfiguration : EntityTypeConfiguration<OrmItemFile>
    {
        public ItemFileConfiguration()
        {
            ToTable("ItemFile");
        }
    }
}
