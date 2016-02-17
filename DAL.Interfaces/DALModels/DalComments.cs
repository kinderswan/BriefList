using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DALModels
{
    public class DalComments
    {
    
        public int Id { get; set; }
        public string Comment { get; set; }
        public int OwnerId { get; set; }
        public int DalItemId { get; set; }
    }
}
