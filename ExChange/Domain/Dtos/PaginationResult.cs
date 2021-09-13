using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PaginationResult<Model> where Model : class, IBaseModel, new()
    {
        public List<Model> Items { get; set; }
        public long TotalCount { get; set; }
    }
}
