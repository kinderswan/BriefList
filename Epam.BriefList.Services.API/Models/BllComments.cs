namespace Epam.BriefList.Services.API.Models
{
    public class BllComments
    {    
        public int Id { get; set; }
        public string Comment { get; set; }
        public int OwnerId { get; set; }
        public int BllItemId { get; set; }
    }
}
