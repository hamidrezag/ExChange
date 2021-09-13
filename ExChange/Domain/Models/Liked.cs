using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Liked:BaseModel
    {
        public long UserId { get; set; }
        public long PostId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }

    }
}
