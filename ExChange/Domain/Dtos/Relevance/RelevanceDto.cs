using Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Relevance
{
    public class RelevanceDto
    {
        public long FollowerUserId { get; set; }
        public long FollowedUserId { get; set; }
        public RelevanceState State { get; set; }
    }
}
