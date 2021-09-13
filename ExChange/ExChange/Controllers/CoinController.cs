using Domain.Dtos.Coin;
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
    
    public class CoinController : BaseController<Coin,CoinDto>
    {
        public CoinController(ICoinServices service) : base(service)
        {
        }
    }
}
