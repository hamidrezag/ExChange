using Domain.Dtos.Coin;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CoinServices:BaseServices<Coin,CoinDto>,ICoinServices
    {
        public CoinServices(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
