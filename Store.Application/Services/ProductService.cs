using AutoMapper;
using Store.Application.DTOs.Category;
using Store.Application.DTOs.Product;
using Store.Application.DTOs.SubCategory;
using Store.Application.Interfaces;
using Store.Application.Repositories;
using Store.Domain.Entities;

namespace Store.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductInfosRepository _productInfosRepository;
    private readonly IProductCategoriesRepository _productCategoriesRepository;
    private readonly IProductSubCategoriesRepository _productSubCategoriesRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IProductInfosRepository productInfosRepository, IMapper mapper, IUnitOfWork unitOfWork, IProductCategoriesRepository productCategoriesRepository, IProductSubCategoriesRepository productSubCategoriesRepository)
    {
        _productInfosRepository = productInfosRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _productCategoriesRepository = productCategoriesRepository;
        _productSubCategoriesRepository = productSubCategoriesRepository;
    }
    
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        var products = await _productInfosRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productInfosRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto productDto, CancellationToken cancellationToken)
    {
        var category = await _productCategoriesRepository.GetAsync(productDto.CategoryId, cancellationToken);

        if (category == null)
        {
            throw new KeyNotFoundException($"Category with id: {productDto.CategoryId} does not exist.");
        }

        if (productDto.SubCategoryId.HasValue)
        {
            var subCategory = await _productSubCategoriesRepository.GetAsync(productDto.SubCategoryId.Value, cancellationToken);
            if (subCategory == null)
                throw new KeyNotFoundException($"SubCategory with id: {productDto.SubCategoryId} does not exist.");
        }

        var product = _mapper.Map<CreateProductDto, ProductInfo>(productDto);
        _productInfosRepository.Add(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto productDto, CancellationToken cancellationToken)
    {
        var product = await _productInfosRepository.GetAsync(id, cancellationToken);

        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        var category = await _productCategoriesRepository.GetAsync(productDto.CategoryId, cancellationToken);

        if (category == null)
        {
            throw new KeyNotFoundException($"Category with id: {productDto.CategoryId} does not exist.");
        }

        if (productDto.SubCategoryId.HasValue)
        {
            var subCategory = await _productSubCategoriesRepository.GetAsync(productDto.SubCategoryId.Value, cancellationToken);
            if (subCategory == null)
                throw new KeyNotFoundException($"SubCategory with id: {productDto.SubCategoryId} does not exist.");
        }

        _mapper.Map(productDto, product);
        _productInfosRepository.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<Guid> DeleteProductAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productInfosRepository.GetAsync(id, cancellationToken);
        
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        _productInfosRepository.Remove(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return id;
    }

    public async Task<IEnumerable<ProductDto>> GetNewPopularProductsAsync(CancellationToken cancellationToken)
    {
        var products = await _productInfosRepository.GetNewProductsAsync(10, cancellationToken);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryId(Guid id, CancellationToken cancellationToken)
    {
        var products = await _productInfosRepository.GetAllByCategoryIdAsync(id, cancellationToken);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await _productCategoriesRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
    
    public async Task<CategoryDto> GetCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _productCategoriesRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto,
        CancellationToken cancellationToken)
    {
        var category = _mapper.Map<CreateCategoryDto, ProductCategory>(categoryDto);
        _productCategoriesRepository.Add(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto,
        CancellationToken cancellationToken)
    {
        var category = await _productCategoriesRepository.GetAsync(id, cancellationToken);

        if (category == null)
        {
            throw new KeyNotFoundException("Category not found");
        }
        
        _mapper.Map(categoryDto, category);
        _productCategoriesRepository.Update(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<Guid> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _productCategoriesRepository.GetAsync(id, cancellationToken);

        if (category == null)
        {
            throw new KeyNotFoundException("Category not found");
        }
        
        _productCategoriesRepository.Remove(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return id;
    }

    public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync(CancellationToken cancellationToken)
    {
        var subCategories = await _productSubCategoriesRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
    }

    public async Task<SubCategoryDto> GetSubCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        var subCategory = await _productSubCategoriesRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<SubCategoryDto>(subCategory);
    }

    public async Task<SubCategoryDto> CreateSubCategoryAsync(CreateSubCategoryDto subCategoryDto,
        CancellationToken cancellationToken)
    {
        var category = await _productCategoriesRepository.GetAsync(subCategoryDto.CategoryId, cancellationToken);

        if (category == null)
        {
            throw new KeyNotFoundException($"Category with id: {subCategoryDto.CategoryId} does not exist.");
        }
        
        var subCategory = _mapper.Map<CreateSubCategoryDto, ProductSubCategory>(subCategoryDto);
        _productSubCategoriesRepository.Add(subCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<SubCategoryDto>(subCategory);
    }

    public async Task<SubCategoryDto> UpdateSubCategoryAsync(Guid id, UpdateSubCategoryDto subCategoryDto,
        CancellationToken cancellationToken)
    {
        var subCategory = await _productSubCategoriesRepository.GetAsync(id, cancellationToken);

        if (subCategory == null)
        {
            throw new KeyNotFoundException("SubCategory not found");
        }
        
        _mapper.Map(subCategoryDto, subCategory);
        _productSubCategoriesRepository.Update(subCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<SubCategoryDto>(subCategory);
    }

    public async Task<Guid> DeleteSubCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        var subCategory = await _productSubCategoriesRepository.GetAsync(id, cancellationToken);

        if (subCategory == null)
        {
            throw new KeyNotFoundException("SubCategory not found");
        }
        
        _productSubCategoriesRepository.Remove(subCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return id;
    }

    public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesByCategoryIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var subCategories = await _productSubCategoriesRepository.GetAllByCategoryIdAsync(id, cancellationToken);
        return _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
    }
}