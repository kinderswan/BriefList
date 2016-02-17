namespace BLL.Interfaces.BLLModels
{
    public class BllSubItem
    {
        public int ID { get; set; }
        public string  Title { get; set; }
        public bool Completed { get; set; } 
        public int BllItemID { get; set; }
    }
}
