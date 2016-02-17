using System;
using System.Collections.Generic;

namespace DAL.Interfaces.DALModels
{
    public class DalList // todo: many to many
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; } // consider to make this better
        
    }
}
