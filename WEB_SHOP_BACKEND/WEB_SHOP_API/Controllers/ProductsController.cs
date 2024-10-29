using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_SHOP_API.Data;
using WEB_SHOP_API.Entities;
using WEB_SHOP_REPOSITORY.Interfaces;

namespace WEB_SHOP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public IGenericRepository<Product> ProductsRepo { get; }
        public IGenericRepository<ProductBrand> ProductBrandRepo { get; }
        public IGenericRepository<ProductType> ProductTypeRepo { get; }

        public ProductsController(IGenericRepository<Product> productsRepo,
             IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo)
        {
            ProductsRepo = productsRepo;
            ProductBrandRepo = productBrandRepo;
            ProductTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await ProductsRepo.ListAllAsync();

            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductBrands()
        {
            return Ok(await ProductBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypes()
        {
            return Ok(await ProductTypeRepo.ListAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await ProductsRepo.GetByIdAsync(id);
        }
    }
}
