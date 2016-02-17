namespace BLL.Interfaces.BLLModels
{
    public class BllItemFile
    {
        public int ID { get; set; }
        public string Filename { get; set; }
        public byte[] File { get; set; }
        public int BllItemID { get; set; }
    }
}
