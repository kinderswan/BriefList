using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ORMModels
{
    public partial class OrmList // todo: many to many
    {
        public OrmList()
        {
            OrmItems = new HashSet<OrmItem>();
            OrmUserProfiles = new HashSet<OrmUserProfile>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; } // consider to make this better


        public virtual ICollection<OrmItem> OrmItems { get; set; }
        public virtual ICollection<OrmUserProfile> OrmUserProfiles { get; set; }

        // public int OrmUserProfileId { get; set; }
        //  public virtual OrmUserProfile OrmUserProfile { get; set; }

    }
}
