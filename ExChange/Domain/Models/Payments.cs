using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Payments:BaseModel
    {
        public long UserId { get; set; }
        public long PaymentsValue { get; set; }
        public DateTime CreationDate { get; set; }
        public string PaymentId { get; set; }
        public virtual User User { get; set; }
    }
}
