using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ORMModels
{
    public class OrmSubItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public int OrmItemID { get; set; }
        public virtual OrmItem OrmItem { get; set; }
    }
}
