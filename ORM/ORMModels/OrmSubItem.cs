namespace ORM.ORMModels
{
    public class OrmSubItem : IOrmEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public int OrmItemId { get; set; }
        public virtual OrmItem OrmItem { get; set; }
    }
}
