using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ORMModels
{
    public partial class OrmItemFile
    {
        public int Id { get; set; }
        public string Filename { get; set; }

        public byte[] File { get; set; }

        public int OrmItemId { get; set; }
        public virtual OrmItem OrmItem { get; set; }
    }
}
