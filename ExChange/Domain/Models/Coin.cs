
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Coin:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<Trade> FromTrade { get; set; }
        public virtual ICollection<Trade> ToTrade { get; set; }

    }
}
