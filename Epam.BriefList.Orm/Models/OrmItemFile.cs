namespace Epam.BriefList.Orm.Models
{
    public class OrmItemFile : IOrmEntity
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public byte[] File { get; set; }
        public int OrmItemId { get; set; }


        public virtual OrmItem OrmItem { get; set; }
    }
}
