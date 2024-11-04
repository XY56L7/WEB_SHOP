using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_SHOP_API.Data;
using WEB_SHOP_API.Dto;
using WEB_SHOP_API.Entities;
using WEB_SHOP_REPOSITORY.Interfaces;
using WEB_SHOP_REPOSITORY.Specifications;

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
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithBrandsAndTypesSpecification();

            var products = await ProductsRepo.ListAync(spec);

            return Ok(products.Select(x => new ProductToReturnDto 
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                PcitureUrl = x.PcitureUrl,
                Price = x.Price,
                ProductBrand = x.ProductBrand.Name,
                ProductType = x.ProductType.Name
            }).ToList());
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
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithBrandsAndTypesSpecification(id);

            var product = await ProductsRepo.GetEntityWithSpec(spec);

            return new ProductToReturnDto
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                PcitureUrl = product.PcitureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            };
        }
    }
}
