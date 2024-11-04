using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Linq;
using WEB_SHOP_REPOSITORY.Interfaces;

namespace WEB_SHOP_REPOSITORY.Specifications
{
    public class SpecificationEvaluater<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecifications<TEntity> spec) 
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
