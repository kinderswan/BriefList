namespace BLL.Interfaces.BLLModels
{
    public class BllSubItem
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public bool Completed { get; set; } 
        public int BllItemId { get; set; }
    }
}
