using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class Utils
    {

        public static IQueryable<T> Pagination<T, TOrderProp>(this IQueryable<T> query, int pageSize, int pageNumber, Expression<Func<T, TOrderProp>> orderField = null, bool ascSorted = true)
            where T : class, IBaseModel
        {

            if (orderField == null)
                return Paginate(query, pageSize, pageNumber, x => x.Id, ascSorted);
            else
                return Paginate(query, pageSize, pageNumber, orderField, ascSorted);
        }
        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, int pageSize, int pageNumber, string orderField = null, bool ascSorted = true)
            where T : class, IBaseModel
        {

            if (orderField == null)
                return Paginate(query, pageSize, pageNumber, x => x.Id, ascSorted);
            else
                return Paginate(query, pageSize, pageNumber, orderField, ascSorted);
        }
        public static IQueryable<T> Paginate<T, TOrderProp>(this IQueryable<T> query, int pageSize, int pageNumber, Expression<Func<T, TOrderProp>> orderField, bool ascSorted = true)
        {
            query = ascSorted ? query.OrderBy(orderField) : query.OrderByDescending(orderField);
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageSize, int pageNumber, string orderField, bool ascSorted = true)
        {
            query = ascSorted ? query.OrderBy(orderField) : query.OrderByDescending(orderField);
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        public static PropertyInfo ToPropertyInfo<TSource, TProperty>(this Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);
            MemberExpression member = propertyLambda.Body as MemberExpression;

            if (member == null)
            {
                var ubody = (UnaryExpression)propertyLambda.Body;
                member = ubody.Operand as MemberExpression;
                if (member == null)
                    throw new ArgumentException(string.Format(
                        "Expression '{0}' refers to a method, not a property.",
                        propertyLambda.ToString()));
            }

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));

            return propInfo;
        }
        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);

            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            var enumarableType = typeof(Queryable);
            var method = enumarableType.GetMethods()
                 .Where(m => m.Name == "OrderBy" && m.IsGenericMethodDefinition)
                 .Where(m =>
                 {
                     var parameters = m.GetParameters().ToList();
             //Put more restriction here to ensure selecting the right overload                
             return parameters.Count == 2;//overload that has 2 parameters
         }).Single();
            //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

            /*Call query.OrderBy(selector), with query and selector: x=> x.PropName
              Note that we pass the selector as Expression to the method and we don't compile it.
              By doing so EF can extract "order by" columns and generate SQL for it.*/
            var newQuery = (IOrderedQueryable<TSource>)genericMethod
                 .Invoke(genericMethod, new object[] { query, selector });
            return newQuery;
        }
        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);

            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            var enumarableType = typeof(Queryable);
            var method = enumarableType.GetMethods()
                 .Where(m => m.Name == "OrderByDescending" && m.IsGenericMethodDefinition)
                 .Where(m =>
                 {
                     var parameters = m.GetParameters().ToList();
                     //Put more restriction here to ensure selecting the right overload                
                     return parameters.Count == 2;//overload that has 2 parameters
                 }).Single();
            //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

            /*Call query.OrderBy(selector), with query and selector: x=> x.PropName
              Note that we pass the selector as Expression to the method and we don't compile it.
              By doing so EF can extract "order by" columns and generate SQL for it.*/
            var newQuery = (IOrderedQueryable<TSource>)genericMethod
                 .Invoke(genericMethod, new object[] { query, selector });
            return newQuery;
        }
        public static T WithOutNestedClass<T>(this T param)
        {
            var t = param.GetType();
            var props = t.GetProperties();
            foreach(var item in props)
            {
                if (item.GetType() is IBaseModel)
                {
                    item.SetValue(param, null);
                }
            }
            return param;
        }
        public static ICollection<T> WithOutNestedClass<T>(this ICollection<T> param)
        {
            List<T> collection = new List<T>();
            foreach (var item in param)
            {
                collection.Add(item.WithOutNestedClass());
            }
            return collection;
        }
    }
}
