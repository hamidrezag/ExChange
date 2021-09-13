using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IBaseServices<Model,Dto> where Model : class, IBaseModel, new()
    {
        QueryResult<Model> GetOne(long id);
        QueryResult<Model> Insert(Dto item);
        QueryResult<Model> Delete(long id);
        QueryResult<Model> Update(List<Expression<Func<Model, object>>> props, Model model, long id);
        ListQueryResult<Model>  GetAllWithFilter<TOrderKey>(int pageSize, int pageNumber, bool ascSorted, Expression<Func<Model, TOrderKey>> orderField = null, Expression<Func<Model, bool>> filter = null);
        ListQueryResult<Model> GetAllWithFilter(int pageSize, int pageNumber, bool ascSorted, string orderField = null, Expression<Func<Model, bool>> filter = null);
        QueryResult<long> Count();
        IQueryable<Model> GetAllQuery();
        ListQueryResult<Model> GetAll();
        QueryResult<Model> Transaction(Func<QueryResult<Model>> task);
    }
}
