using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Wallet:BaseModel
    {
        public long UserId { get; set; }
        public long CoinId { get; set; }
        public string Value { get; set; }
        public virtual User User { get; set; }
        public virtual Coin Coin { get; set; }
    }
}
