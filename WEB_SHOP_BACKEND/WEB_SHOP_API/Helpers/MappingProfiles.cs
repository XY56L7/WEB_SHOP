using AutoMapper;
using WEB_SHOP_API.Dto;
using WEB_SHOP_API.Entities;

namespace WEB_SHOP_API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand,o => o.MapFrom(x => x.ProductBrand.Name))
                .ForMember(d => d.ProductType,o => o.MapFrom(x => x.ProductType.Name));
;        }
    }
}
