using System;

namespace BLL.Interfaces.BLLModels
{
    public class BllItem
    {
        public int ID { get; set; }

        public bool Completed { get; set; }
        public bool Starred { get; set; }

        public string Title { get; set; }

        public DateTime? TimeComplete { get; set; }

        public int BllListID { get; set; }
        

    }
}
