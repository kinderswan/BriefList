using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DALModels
{
    public class DalComments
    {    
        public int ID { get; set; }
        public string Comment { get; set; }
        public int OwnerID { get; set; }
        public int DalItemID { get; set; }
    }
}
