using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    [Table("Item")]
    public partial class OrmItem
    {
        public int Id { get; set; }
        public bool Complete { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public DateTime TimeComplete { get; set; }

        public int OrmListId { get; set; }
        public virtual OrmList OrmList { get; set; }

    }
}
