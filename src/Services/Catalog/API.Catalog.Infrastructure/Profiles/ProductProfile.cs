using API.Catalog.Core.Entities;
using API.Catalog.Infrastructure.Dtos;
using API.Catalog.Infrastructure.Helpers;
using AutoMapper;

namespace API.Catalog.Infrastructure.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(x => x.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(x => x.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());

            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductBrand, ProductBrandDto>();
        }
    }
}
