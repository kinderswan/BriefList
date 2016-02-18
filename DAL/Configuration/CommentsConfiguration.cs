using ORM.ORMModels;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
{
    public class CommentsConfiguration : EntityTypeConfiguration<OrmComments>
    {
        public CommentsConfiguration()
        {
            ToTable("Comments");
        }
    }
}
