using Domain.Dtos.Comment;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CommentsServices:BaseServices<Comments,CommentDto>,ICommentsServices
    {
        public CommentsServices(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
