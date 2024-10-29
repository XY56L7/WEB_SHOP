using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_SHOP_API.Entities;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAync();
    }
}
