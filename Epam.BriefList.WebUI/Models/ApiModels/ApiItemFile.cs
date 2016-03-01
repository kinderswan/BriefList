namespace Epam.BriefList.WebUI.Models.ApiModels
{
    public class ApiItemFile
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public byte[] File { get; set; }
        public int BllItemId { get; set; }
    }
}
