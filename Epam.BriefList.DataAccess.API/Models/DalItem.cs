using System;

namespace Epam.BriefList.DataAccess.API.Models
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
