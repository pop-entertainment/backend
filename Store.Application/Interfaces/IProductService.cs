using Store.Application.DTOs.Category;
using Store.Application.DTOs.Product;
using Store.Application.DTOs.SubCategory;

namespace Store.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken);
    Task<ProductDto> GetProductAsync(Guid id, CancellationToken cancellationToken);
    Task<ProductDto> CreateProductAsync(CreateProductDto productDto, CancellationToken cancellationToken);
    Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto productDto, CancellationToken cancellationToken);
    Task<Guid> DeleteProductAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<ProductDto>> GetNewPopularProductsAsync(CancellationToken cancellationToken);
    Task<IEnumerable<ProductDto>> GetProductsByCategoryId(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken);
    Task<CategoryDto> GetCategoryAsync(Guid id, CancellationToken cancellationToken);
    Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto,
        CancellationToken cancellationToken);
    Task<CategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto,
        CancellationToken cancellationToken);
    Task<Guid> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync(CancellationToken cancellationToken);
    Task<SubCategoryDto> GetSubCategoryAsync(Guid id, CancellationToken cancellationToken);
    Task<SubCategoryDto> CreateSubCategoryAsync(CreateSubCategoryDto subCategoryDto,
        CancellationToken cancellationToken);
    Task<SubCategoryDto> UpdateSubCategoryAsync(Guid id, UpdateSubCategoryDto subCategoryDto,
        CancellationToken cancellationToken);
    Task<Guid> DeleteSubCategoryAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesByCategoryIdAsync(Guid id,
        CancellationToken cancellationToken);
}