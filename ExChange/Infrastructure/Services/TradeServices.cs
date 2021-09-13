using Domain.Dtos.Trade;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TradeServices : BaseServices<Trade,TradeDto>, ITradeServices
    {
        public TradeServices(AppDbContext datamodel) : base(datamodel)
        {
        }
    }
}
