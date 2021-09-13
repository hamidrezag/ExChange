using Domain.Dtos.Liked;
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
    public class LikedController : BaseController<Liked,LikedDto>
    {
        public LikedController(ILikedServices service) : base(service)
        {
        }
    }
}
