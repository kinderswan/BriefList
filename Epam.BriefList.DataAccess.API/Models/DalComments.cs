namespace Epam.BriefList.DataAccess.API.Models
{
    public class DalComments
    {    
        public int Id { get; set; }
        public string Comment { get; set; }
        public int OwnerId { get; set; }
        public int DalItemId { get; set; }
    }
}
