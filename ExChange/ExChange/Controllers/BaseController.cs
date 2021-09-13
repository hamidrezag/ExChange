using Domain.Dtos;
using Domain.Extensions;
using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController<Model,Dto> : ControllerBase
        where Model : class, IBaseModel, new()
    {
        protected IBaseServices<Model,Dto> _Service;
        public BaseController(IBaseServices<Model,Dto> service)
        {
            _Service = service;
        }
        protected QueryResult<Model> UpdateModel(List<Expression<Func<Model, object>>> props, Model model)
        {
            var result = _Service.Update(props, model, model.Id);
            return result;
        }
        [HttpDelete("Delete")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = _Service.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("Insert")]
        public virtual async Task<IActionResult> Insert([FromBody] Dto item)
        {
            var result = _Service.Insert(item);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetPaginatedList")]
        public virtual async Task<IActionResult> GetPaginatedList([FromQuery]PaginationParam param)
        {
            var listQueryResult = _Service.GetAllWithFilter(param.PageSize, param.PageNumber, param.AscSort, param.Order);
            if (!listQueryResult.Success)
                return BadRequest(listQueryResult);

            var countQueryResult = _Service.Count();
            if (!countQueryResult.Success)
                return BadRequest(countQueryResult);

            return Ok(new PaginationResult<Model> { 
                Items = listQueryResult.Model.WithOutNestedClass(),
                TotalCount = countQueryResult.Model
            });
        }
    }
}
