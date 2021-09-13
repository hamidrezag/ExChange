using Domain.Dtos.Payment;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PaymentServices:BaseServices<Payments,PaymentDto>,IPaymentServices
    {
        public PaymentServices(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
