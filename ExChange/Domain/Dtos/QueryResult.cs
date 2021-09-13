using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class QueryResult<TModel>
    {
        public TModel Model { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class ListQueryResult<TModel>
    {
        public List<TModel> Model { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
