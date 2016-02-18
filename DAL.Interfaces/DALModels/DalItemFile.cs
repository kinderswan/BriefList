namespace DAL.Interfaces.DALModels
{
    public class DalItemFile
    {
        public int ID { get; set; }
        public string Filename { get; set; }
        public byte[] File { get; set; }
        public int DalItemID { get; set; }
    }
}
