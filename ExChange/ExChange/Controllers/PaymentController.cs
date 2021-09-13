using Domain.Dtos.Payment;
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
    public class PaymentController : BaseController<Payments,PaymentDto>
    {
        public PaymentController(IPaymentServices service) : base(service)
        {
        }
    }
}
