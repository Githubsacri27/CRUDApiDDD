using AutoMapper;
using TestVH.Infrastructure.Contracts.Entities;
using TestVH.Library.Contracts.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestVH.Library.Impl
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.categoryId));

            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.categoryId, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}
