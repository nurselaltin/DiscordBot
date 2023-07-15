namespace Data.Entity
{
    public class Link : BaseEntity
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public int TypeLink { get; set; }
        public string LinkAddress { get; set; }
    }
}
