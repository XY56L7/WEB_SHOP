using AutoMapper;
using Microsoft.Extensions.Configuration;
using WEB_SHOP_API.Dto;
using WEB_SHOP_API.Entities;

namespace WEB_SHOP_API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration config;
        public ProductUrlResolver(IConfiguration config)
        {
            this.config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, 
            string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) 
            {
                return config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
