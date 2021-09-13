using Domain.Dtos.Liked;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LikedServices:BaseServices<Liked,LikedDto>,ILikedServices
    {
        public LikedServices(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
