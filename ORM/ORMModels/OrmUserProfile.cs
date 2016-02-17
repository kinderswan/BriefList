using System;
using System.Collections.Generic;

namespace ORM.ORMModels
{
    public class OrmUserProfile
    {
        public OrmUserProfile()
        {
            OrmLists = new HashSet<OrmList>();
        }


        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public DateTime TimeRegister { get; set; }


        public virtual ICollection<OrmList> OrmLists { get; set; }

    }
}
