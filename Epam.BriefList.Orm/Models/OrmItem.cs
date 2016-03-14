﻿using System;
using System.Collections.Generic;

namespace Epam.BriefList.Orm.Models
{
    public class OrmItem : IOrmEntity
    {
        public OrmItem()
        {
            ItemFiles = new HashSet<OrmItemFile>();
            SubItems = new HashSet<OrmSubItem>();
            Comments = new HashSet<OrmComments>();
        }


        public int Id { get; set; }
        public bool Completed { get; set; }
        public bool Starred { get; set; }
        public string Title { get; set; }
        public DateTime? TimeComplete { get; set; }
        public string Comment { get; set; }
        public int OrmListId { get; set; }


        public virtual OrmList OrmList { get; set; }


        public virtual ICollection<OrmItemFile> ItemFiles { get; set; }
        public virtual ICollection<OrmSubItem> SubItems { get; set; }
        public virtual ICollection<OrmComments> Comments { get; set; }

    }
}
