using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TicketDetails:BaseModel
    {
        public long TicketId { get; set; }
        public string Context { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
    }
}
