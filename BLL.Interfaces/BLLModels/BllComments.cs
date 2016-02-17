namespace BLL.Interfaces.BLLModels
{
    public class BllComments
    {    
        public int ID { get; set; }
        public string Comment { get; set; }
        public int OwnerID { get; set; }
        public int BllItemID { get; set; }
    }
}
