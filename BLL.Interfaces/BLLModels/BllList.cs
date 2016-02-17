namespace BLL.Interfaces.BLLModels
{
    public class BllList // todo: many to many
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerID { get; set; } // consider to make this better
        

    }
}
