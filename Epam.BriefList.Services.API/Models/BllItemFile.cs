namespace Epam.BriefList.Services.API.Models
{
    public class BllItemFile
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public byte[] File { get; set; }
        public int BllItemId { get; set; }
    }
}
