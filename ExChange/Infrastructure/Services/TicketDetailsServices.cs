using Domain.Dtos.TicketDetails;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TicketDetailsServices : BaseServices<TicketDetails,TicketDetailsDto>, ITicketDetailsServices
    {
        public TicketDetailsServices(AppDbContext datamodel) : base(datamodel)
        {
        }
    }
}
