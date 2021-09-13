using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TicketAttachment:BaseModel
    {
        public long TicketDetailsId { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual TicketDetails TicketDetails { get; set; }
    }
}
