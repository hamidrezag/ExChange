using Domain.Dtos.Ticket;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TicketServices:BaseServices<Ticket,TicketDto>,ITicketServices
    {
        public TicketServices(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
