using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_SHOP_API.Data;
using WEB_SHOP_REPOSITORY.Interfaces;
using WEB_SHOP_REPOSITORY.Specifications;

namespace WEB_SHOP_REPOSITORY.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext context;

        public GenericRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecifications(ISpecifications<T> specifications) 
        {
            return SpecificationEvaluater<T>.GetQuery(context.Set<T>().AsQueryable(),specifications);
        }
    }
}
