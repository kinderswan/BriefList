using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class OrmList
    {
        public OrmList()
        {
            OrmItems = new HashSet<OrmItem>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }

        public virtual ICollection<OrmItem> OrmItems { get; set; }



        public int OrmUserProfileId { get; set; }
        public virtual OrmUserProfile OrmUserProfile { get; set; }

    }
}
