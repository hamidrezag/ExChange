using Domain.Dtos.Post;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PostServices:BaseServices<Post,PostDto>,IPostServices
    {
        public PostServices(AppDbContext dbContext ):base(dbContext)
        {

        }
    }
}
