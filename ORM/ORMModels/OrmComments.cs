using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ORMModels
{
    public partial class OrmComments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public OrmUserProfile Owner { get; set; }

        public int OrmItemId { get; set; }
        public virtual OrmItem OrmItem { get; set;}
    }
}
