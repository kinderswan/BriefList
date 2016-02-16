using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Configuration
{
    public class SubItemConfiguration : EntityTypeConfiguration<OrmSubItem>
    {
        public SubItemConfiguration()
        {
            ToTable("SubItem");            
        }
    }
}
