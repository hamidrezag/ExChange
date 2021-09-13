using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comments:BaseModel
    {
        public long PostId { get; set; }
        public long UserId { get; set; }
        public string Context { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }

    }
}
