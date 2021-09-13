using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User: IdentityUser<long>,IBaseModel
    {
        public string NashnalCode { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Liked> Liked { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<Relevance> Followed { get; set; }
        public virtual ICollection<Relevance> Follower { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }
    }
}
