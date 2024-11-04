using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WEB_SHOP_API.Entities;

namespace WEB_SHOP_REPOSITORY.Specifications
{
    public class ProductsWithBrandsAndTypesSpecification : BaseSpecifications<Product>
    {
        public ProductsWithBrandsAndTypesSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithBrandsAndTypesSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
