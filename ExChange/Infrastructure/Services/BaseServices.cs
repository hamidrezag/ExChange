using AutoMapper;
using Domain.Dtos;
using Domain.Extensions;
using Domain.IServices;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BaseServices<Model,Dto> : IBaseServices<Model,Dto> where Model : class, IBaseModel, new()
    {
        private readonly IMapper _mapper;
        public BaseServices(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AppDbContext _DbContext { get; set; }
        public BaseServices(AppDbContext datamodel)
        {
            _DbContext = datamodel;
        }
        public QueryResult<Model> Delete(long id)
        {
            try
            {
                var _table = _DbContext.Set<Model>();
                _table.Remove(_table.FirstOrDefault(x => x.Id == id));
                _DbContext.SaveChanges();
                return new QueryResult<Model>
                {
                    Success = true,
                    Message = "اطلاعات شما با موفقیت حذف شد"
                };
            }
            catch (Exception ex)
            {
                return new QueryResult<Model>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        public QueryResult<Model> GetOne(long id)
        {
            try
            {
                return new QueryResult<Model> { 
                    Model = _DbContext.Set<Model>().FirstOrDefault(x => x.Id == id),
                    Success = true
                };

            }
            catch(Exception ex)
            {
                return new QueryResult<Model>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        public QueryResult<Model> Insert(Dto item)
        {
            try
            {
                var _table = _DbContext.Set<Model>();
                Model aa = new Model();
                aa = _mapper.Map<Model>(item);
                var dbItem = _table.Add(aa) as Model;
                int result = _DbContext.SaveChanges();
                return new QueryResult<Model>
                {
                    Success = true,
                    Model = dbItem,
                    Message = "اطلاعات شما با موفقیت ثبت شد"
                };
            }
            catch (Exception ex)
            {
                return new QueryResult<Model>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
        public QueryResult<Model> Transaction(Func<QueryResult<Model>> task)
        {
            using (IDbContextTransaction dbTran = _DbContext.Database.BeginTransaction())
            {
                QueryResult<Model> result;
                try
                {
                    task();
                    dbTran.Commit();
                    result = new QueryResult<Model>
                    {
                        Message = "عملیات با موفقیت انجام شد",
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    result = new QueryResult<Model>
                    {
                        Message = ex.Message,
                        Success = false
                    };
                }
                finally
                {
                    dbTran.Dispose();
                }
                return result;
            }
        }
        public QueryResult<Model> Update(List<Expression<Func<Model, object>>> props, Model model, long id)
        {
            try
            {
                var _table = _DbContext.Set<Model>();
                var item = _table.FirstOrDefault(x => x.Id == id);
                foreach (var el in props)
                {
                    PropertyInfo prop = el.ToPropertyInfo();
                    if (item.GetType().GetProperties().Any(x => x.Name == prop.Name))
                    {
                        var itemprop = item.GetType().GetProperty(prop.Name);
                        var valueOfModel = model.GetType().GetProperty(prop.Name).GetValue(model);
                        itemprop.SetValue(item, valueOfModel);
                    }
                }
                int result = _DbContext.SaveChanges();
                return new QueryResult<Model>
                {
                    Success = true,
                    Model = item,
                    Message = "اطلاعات شما با موفقیت ثبت شد"
                };
            }
            catch (Exception ex)
            {
                return new QueryResult<Model>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        public IQueryable<Model> GetAllQuery()
        {
            return _DbContext.Set<Model>().AsQueryable();
        }
        public ListQueryResult<Model> GetAllWithFilter<TOrderProp>(int pageSize, int pageNumber, bool ascSorted, Expression<Func<Model, TOrderProp>> orderField = null, Expression<Func<Model, bool>> filter = null)
        {
            try
            {
                return new ListQueryResult<Model>
                {
                    Model = filter is null ?
                           _DbContext.Set<Model>().Pagination(pageSize, pageNumber, orderField, ascSorted).ToList()
                          : _DbContext.Set<Model>().Where(filter).Pagination(pageSize, pageNumber, orderField, ascSorted).ToList(),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ListQueryResult<Model>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        public ListQueryResult<Model> GetAllWithFilter(int pageSize, int pageNumber, bool ascSorted, string orderField = null, Expression<Func<Model, bool>> filter = null)
        {
            try
            {
                var model = filter is null ?
                _DbContext.Set<Model>().Pagination(pageSize, pageNumber, orderField, ascSorted).ToList()
                : _DbContext.Set<Model>().Where(filter).Pagination(pageSize, pageNumber, orderField, ascSorted).ToList();
                return new ListQueryResult<Model>
                {
                    Success = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                return new ListQueryResult<Model>
                {
                    Success = false,
                    Message = ex.Message
                };
            }

        }
        public ListQueryResult<Model> GetAll()
        {
            try
            {
                return new ListQueryResult<Model>
                {
                    Model = _DbContext.Set<Model>().ToList(),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ListQueryResult<Model>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            
        }
        public QueryResult<long> Count()
        {
            try
            {
                return new QueryResult<long>
                {
                    Model = _DbContext.Set<Model>().Count(),
                    Success = true
                };
            }
            catch(Exception ex)
            {
                return new QueryResult<long>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
