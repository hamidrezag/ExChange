using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Payment
{
    public class PaymentDto
    {
        public long UserId { get; set; }
        public long PaymentsValue { get; set; }
        public DateTime CreationDate { get; set; }
        public string PaymentId { get; set; }
    }
}
