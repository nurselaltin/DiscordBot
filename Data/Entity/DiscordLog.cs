using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class DiscordLog
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
