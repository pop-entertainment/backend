using AutoMapper;
using Store.Application.DTOs.Product;
using Store.Domain.Entities;

namespace Store.Application.AutoMapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductInfo, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
            .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory != null ? src.SubCategory.SubCategoryName : null))
            .ReverseMap();
        CreateMap<CreateProductDto, ProductInfo>().ReverseMap();
        CreateMap<UpdateProductDto, ProductInfo>().ReverseMap();
    }
}