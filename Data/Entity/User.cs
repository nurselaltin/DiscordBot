using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public  class User : BaseEntity
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string AccountName { get; set; }
        public int Platform { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsCreater { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
