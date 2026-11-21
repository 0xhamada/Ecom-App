using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;

namespace Ecom.API.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
             CreateMap<Product, ProductDTO>()
                .ForMember(dst=>dst.CategoryName, opt =>
                opt.MapFrom(src => src.Categories != null ? src.Categories.Name : null))
                .ForMember(dst=>dst.Price, opt=>opt.MapFrom(src=>src.NewPrice));
            CreateMap<Photo, PhotoDTO>().ReverseMap();
            CreateMap<AddProductDTO, Product>()
                .ForMember(dst => dst.Photos, op=> op.Ignore())
                .ReverseMap();
            CreateMap<UpdateProductDTO, Product>()
                .ForMember(dst => dst.Photos, op => op.Ignore())
                .ReverseMap();
        }
    }
}
