using ORM.ORMModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
