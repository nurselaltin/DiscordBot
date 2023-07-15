namespace Data.Entity
{
    public class DiscordLog : BaseEntity
    {
        public int ID { get; set; }
        public int TypeLink { get; set; }
        public string AccountName { get; set; }
        public string Member { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
