using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_SHOP_API.Data;
using WEB_SHOP_API.Entities;

namespace Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAync()
        {
            return await context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAync()
        {
            return await context.Products
                                .Include(p => p.ProductType)
                                .Include(p => p.ProductBrand)
                                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAync()
        {
            return await context.ProductTypes.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products
                                .Include(p => p.ProductType)
                                .Include(p => p.ProductBrand)
                                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
