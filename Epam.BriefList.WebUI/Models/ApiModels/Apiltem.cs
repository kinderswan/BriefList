using System;

namespace Epam.BriefList.WebUI.Models.ApiModels
{
    public class ApiItem
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public bool Starred { get; set; }
        public string Title { get; set; }
        public DateTime? TimeComplete { get; set; }
        public int ListId { get; set; }      
    }
}
