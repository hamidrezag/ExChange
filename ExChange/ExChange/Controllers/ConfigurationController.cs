using Domain.Dtos.Configuration;
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
    public class ConfigurationController : BaseController<Configurations, ConfigurationDto>
    {
        public ConfigurationController(IConfigurationsServices service) : base(service)
        {
        }
    }
}
