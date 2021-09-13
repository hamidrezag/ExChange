using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ticket:BaseModel
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TicketDetails> TicketDetails { get; set; }
    }
}
