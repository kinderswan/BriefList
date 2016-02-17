using System;
using System.Collections.Generic;

namespace ORM.ORMModels
{
    public class OrmList
    {
        public OrmList()
        {
            OrmItems = new HashSet<OrmItem>();
            OrmUserProfiles = new HashSet<OrmUserProfile>();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerID { get; set; }
        public virtual ICollection<OrmItem> OrmItems { get; set; }
        public virtual ICollection<OrmUserProfile> OrmUserProfiles { get; set; }

    }
}
