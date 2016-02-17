using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ORMModels
{
    public class OrmItemFile
    {
        public int ID { get; set; }
        public string Filename { get; set; }
        public byte[] File { get; set; }
        public int OrmItemID { get; set; }


        public virtual OrmItem OrmItem { get; set; }
    }
}
