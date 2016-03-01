using System.Data.Entity.ModelConfiguration;
using Epam.BriefList.Orm.Models;

namespace Epam.BriefList.DataAccess.MSSQLProvider.Configuration
{
    public class SubItemConfiguration : EntityTypeConfiguration<OrmSubItem>
    {
        public SubItemConfiguration()
        {
            ToTable("SubItem");            
        }
    }
}
