using Domain.Dtos.Role;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RoleServices:BaseServices<Role,RoleDto>,IRoleServices
    {
        public RoleServices(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
