using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DALModels
{
    public class DalSubItem
    {
        public int ID { get; set; }
        public string  Title { get; set; }
        public bool Completed { get; set; }


        public int DalItemId { get; set; }
    }
}
