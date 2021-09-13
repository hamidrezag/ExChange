using Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Relevance:BaseModel
    {
        public long FollowerUserId { get; set; }
        public long FollowedUserId { get; set; }
        public RelevanceState State { get; set; }
        public virtual User FollowerUser { get; set; }
        public virtual User FollowedUser { get; set; }
        
    }
}
