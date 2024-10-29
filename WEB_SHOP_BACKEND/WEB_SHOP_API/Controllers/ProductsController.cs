using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_SHOP_API.Data;
using WEB_SHOP_API.Entities;

namespace WEB_SHOP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository repo;
        public ProductsController(IProductRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await repo.GetProductsAync();

            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductBrands()
        {
            return Ok(await repo.GetProductBrandsAync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypes()
        {
            return Ok(await repo.GetProductTypesAync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await repo.GetProductByIdAsync(id);
        }
    }
}
