﻿using System;
using System.Collections.Generic;

namespace Epam.BriefList.Orm.Models
{
    public class OrmUserProfile : IOrmEntity
    {
        public OrmUserProfile()
        {
            OrmLists = new HashSet<OrmList>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public DateTime TimeRegister { get; set; }
        public virtual ICollection<OrmList> OrmLists { get; set; }

    }
}
