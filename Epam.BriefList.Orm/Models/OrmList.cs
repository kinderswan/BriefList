using System.Collections.Generic;

namespace Epam.BriefList.Orm.Models
{
    public class OrmList : IOrmEntity
    {
        public OrmList()
        {
            OrmItems = new HashSet<OrmItem>();
            OrmUserProfiles = new HashSet<OrmUserProfile>();
        }


        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }


        public virtual ICollection<OrmItem> OrmItems { get; set; }
        public virtual ICollection<OrmUserProfile> OrmUserProfiles { get; set; }

    }
}
