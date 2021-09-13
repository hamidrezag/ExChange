using Domain.Dtos.Wallet;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class WalletServices:BaseServices<Wallet,WalletDto>,IWalletServices
    {
        public WalletServices(AppDbContext dbContext) : base(dbContext) { }
        
    }
}
