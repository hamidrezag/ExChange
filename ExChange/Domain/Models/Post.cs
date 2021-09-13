using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post:BaseModel
    {
        public long UserId { get; set; }
        public string PostContent { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Liked> Liked { get; set; }
    }
}
