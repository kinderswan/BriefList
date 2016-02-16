using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class OrmUserProfile   
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] Photo { get; set; }

        public DateTime TimeRegister { get; set; }


        public OrmUserProfile()
        {
            OrmLists = new HashSet<OrmList>();
        }
        public virtual ICollection<OrmList> OrmLists { get; set; }
    }
}
