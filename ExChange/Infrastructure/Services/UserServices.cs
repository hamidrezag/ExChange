using Domain.Dtos;
using Domain.Dtos.User;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserServices : BaseServices<User,UserDto>,IUserServices
    {
        public UserServices(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
