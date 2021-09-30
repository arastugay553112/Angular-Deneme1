using API.Core.DbModels;
using API.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Aggregate fonksiyonu toplu işlem yapmamızı sağlıyor
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
