using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.TicketAttachment
{
    public class TicketAttachmentsDto
    {
        public long TicketDetailsId { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
