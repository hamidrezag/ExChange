using Domain.Dtos.TicketAttachment;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface ITicketAttachmentsServices:IBaseServices<TicketAttachment,TicketAttachmentsDto>
    {
    }
}
