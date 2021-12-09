using API.Core.DbModels;
using API.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery,ISpecification<TEntity> spec)
        {
            var query = InputQuery;
            if(spec.Creteria != null)
            {
                query = query.Where(spec.Creteria);
            }
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            if (spec.isPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            //Aggregate fonksiyonu toplu işlem yapmamızı sağlıyor
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
