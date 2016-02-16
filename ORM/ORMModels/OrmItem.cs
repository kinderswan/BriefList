using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ORMModels
{
    public partial class OrmItem
    {
        public int Id { get; set; }

        public bool Completed { get; set; }
        public bool Starred { get; set; }// mark task as important

        public string Title { get; set; }

        public DateTime? TimeComplete { get; set; }

        public int OrmListId { get; set; }

        public virtual OrmList OrmList { get; set; }

        public virtual ICollection<OrmItemFile> ItemFiles { get; set; }
        public virtual ICollection<OrmSubItem> SubItems { get; set; }

        public virtual ICollection<OrmComments> Comments { get; set; }

        public OrmItem()
        {
            ItemFiles = new HashSet<OrmItemFile>();
            SubItems = new HashSet<OrmSubItem>();
            Comments = new HashSet<OrmComments>();
        }

    }
}
