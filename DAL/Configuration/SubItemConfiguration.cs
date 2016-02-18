using ORM.ORMModels;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
{
    public class SubItemConfiguration : EntityTypeConfiguration<OrmSubItem>
    {
        public SubItemConfiguration()
        {
            ToTable("SubItem");            
        }
    }
}
