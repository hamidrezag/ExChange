﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.TicketDetails
{
    public class TicketDetailsDto
    {
        public long TicketId { get; set; }
        public string Context { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
