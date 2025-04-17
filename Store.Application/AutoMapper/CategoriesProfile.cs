using AutoMapper;
using Store.Application.DTOs.Category;
using Store.Application.DTOs.SubCategory;
using Store.Domain.Entities;

namespace Store.Application.AutoMapper;

public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<CreateCategoryDto, ProductCategory>().ReverseMap();
        CreateMap<ProductCategory, CategoryDto>().ReverseMap();
        CreateMap<UpdateCategoryDto, CategoryDto>().ReverseMap();
        
        CreateMap<CreateSubCategoryDto, ProductSubCategory>().ReverseMap();
        CreateMap<ProductSubCategory, SubCategoryDto>().ReverseMap();
        CreateMap<UpdateSubCategoryDto, ProductSubCategory>().ReverseMap();
    }
}