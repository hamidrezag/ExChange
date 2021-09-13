using Domain.Dtos.Comment;
using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController<Comments, CommentDto>
    {
        public CommentsController(ICommentsServices service) : base(service)
        {
        }
    }
}
