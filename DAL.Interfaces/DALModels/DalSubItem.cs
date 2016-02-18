namespace DAL.Interfaces.DALModels
{
    public class DalSubItem
    {
        public int ID { get; set; }
        public string  Title { get; set; }
        public bool Completed { get; set; }
        public int DalItemID { get; set; }
    }
}
