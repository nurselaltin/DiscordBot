namespace Data.Entity
{
    public class Link
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public int TypeLink { get; set; }
        public string LinkAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
