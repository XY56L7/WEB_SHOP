using AutoMapper;
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
        private readonly IGenericRepository<Product> _ProductsRepo;
        private readonly IGenericRepository<ProductBrand> _ProductBrandRepo;
        private readonly IGenericRepository<ProductType> _ProductTypeRepo;
        private readonly IMapper _Mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
             IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _ProductsRepo = productsRepo;
            _ProductBrandRepo = productBrandRepo;
            _ProductTypeRepo = productTypeRepo;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithBrandsAndTypesSpecification();

            var products = await _ProductsRepo.ListAync(spec);

            return Ok(_Mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductBrands()
        {
            return Ok(await _ProductBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypes()
        {
            return Ok(await _ProductTypeRepo.ListAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithBrandsAndTypesSpecification(id);

            var product = await _ProductsRepo.GetEntityWithSpec(spec);

            return _Mapper.Map<Product,ProductToReturnDto>(product);
        }
    }
}
