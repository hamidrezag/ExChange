using Domain.Dtos.TicketAttachment;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TicketAttachmentServices : BaseServices<TicketAttachment,TicketAttachmentsDto>, ITicketAttachmentsServices
    {
        public TicketAttachmentServices(AppDbContext datamodel) : base(datamodel)
        {
        }
    }
}
