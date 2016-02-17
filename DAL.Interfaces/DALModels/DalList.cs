using System;
using System.Collections.Generic;

namespace DAL.Interfaces.DALModels
{
    public class DalList
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerID { get; set; }
        
    }
}
