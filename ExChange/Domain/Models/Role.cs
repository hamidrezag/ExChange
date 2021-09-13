using Domain.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Role : IdentityRole<long>,IBaseModel
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
