using System;

namespace DAL.Interfaces.DALModels
{
    public class DalItem
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public bool Starred { get; set; }
        public string Title { get; set; }
        public DateTime? TimeComplete { get; set; }
        public int DalListId { get; set; }
        
    }
}
