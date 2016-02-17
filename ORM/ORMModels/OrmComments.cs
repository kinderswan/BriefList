namespace ORM.ORMModels
{
    public class OrmComments
    {   
        public int ID { get; set; }
        public string Comment { get; set; }
        public int OwnerID { get; set; }
        public int OrmItemID { get; set; }
        public virtual OrmItem OrmItem { get; set;}
    }
}
