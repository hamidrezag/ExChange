using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Wallet
{
    public class WalletDto
    {
        public long UserId { get; set; }
        public long CoinId { get; set; }
        public string Value { get; set; }
    }
}
