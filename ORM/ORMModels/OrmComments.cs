namespace ORM.ORMModels
{
    public class OrmComments
    {   
        public int Id { get; set; }
        public string Comment { get; set; }
        public int OwnerId { get; set; }
        public int OrmItemId { get; set; }
        public virtual OrmItem OrmItem { get; set;}
    }
}
