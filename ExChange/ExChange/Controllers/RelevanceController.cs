using Domain.Dtos.Relevance;
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
    public class RelevanceController : BaseController<Relevance,RelevanceDto>
    {
        public RelevanceController(IRelevanceServices service) : base(service)
        {
        }
    }
}
