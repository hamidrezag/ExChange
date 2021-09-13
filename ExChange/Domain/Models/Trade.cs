using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Trade:BaseModel
    {
        public long UserId { get; set; }
        public long FromCoinId { get; set; }
        public long ToCoinId { get; set; }
        public DateTime CreationDate { get; set; }
        public string TaxId { get; set; }
        public int PercentOfProfit { get; set; }
        public string FromCoinValue { get; set; }
        public string ToCoinValue { get; set; }
        public virtual User User { get; set; }
        public virtual Coin FromCoin { get; set; }
        public virtual Coin ToCoin { get; set; }
    }
}
