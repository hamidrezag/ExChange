using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Trade
{
    public class TradeDto
    {
        public long UserId { get; set; }
        public long FromCoinId { get; set; }
        public long ToCoinId { get; set; }
        public DateTime CreationDate { get; set; }
        public string TaxId { get; set; }
        public int PercentOfProfit { get; set; }
        public string FromCoinValue { get; set; }
        public string ToCoinValue { get; set; }
    }
}
