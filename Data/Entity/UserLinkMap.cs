using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class UserLinkMap
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int LinkId { get; set; }
        public int TypeLink { get; set; }
        public bool IsSuggested { get; set; }
    }
}
