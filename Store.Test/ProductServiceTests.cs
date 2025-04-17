using AutoMapper;
using Moq;
using Store.Application.DTOs.Category;
using Store.Application.DTOs.Product;
using Store.Application.DTOs.SubCategory;
using Store.Application.Interfaces;
using Store.Application.Repositories;
using Store.Application.Services;
using Store.Domain.Entities;
using Xunit;

namespace Store.Test;

public class ProductServiceTests
{
    private readonly Mock<IProductInfosRepository> _productInfosRepositoryMock = new();
    private readonly Mock<IProductCategoriesRepository> _productCategoriesRepositoryMock = new();
    private readonly Mock<IProductSubCategoriesRepository> _productSubCategoriesRepositoryMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateProductDto, ProductInfo>();
            cfg.CreateMap<ProductInfo, ProductDto>();
            cfg.CreateMap<CreateCategoryDto, ProductCategory>();
            cfg.CreateMap<ProductCategory, CategoryDto>();
            cfg.CreateMap<CreateSubCategoryDto, ProductSubCategory>();
            cfg.CreateMap<ProductSubCategory, SubCategoryDto>();
        });

        var mapper = mapperConfig.CreateMapper();

        _productService = new ProductService(
            _productInfosRepositoryMock.Object,
            mapper,
            _unitOfWorkMock.Object,
            _productCategoriesRepositoryMock.Object,
            _productSubCategoriesRepositoryMock.Object
        );
    }

    [Fact]
    public async Task CreateProductAsync_ShouldCreateProduct()
    {
        // Arrange
        var createDto = new CreateProductDto
        {
            Title = "Test Product",
            Description = "Desc",
            Price = 100,
            Discount = 10,
            CategoryId = Guid.NewGuid()
        };

        _productCategoriesRepositoryMock.Setup(x => x.GetAsync(createDto.CategoryId, default))
            .ReturnsAsync(new ProductCategory { Id = createDto.CategoryId });

        // Act
        var result = await _productService.CreateProductAsync(createDto, default);

        // Assert
        _productInfosRepositoryMock.Verify(x => x.Add(It.IsAny<ProductInfo>()), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
        Assert.Equal(createDto.Title, result.Title);
    }

    [Fact]
    public async Task CreateCategoryAsync_ShouldCreateCategory()
    {
        // Arrange
        var createDto = new CreateCategoryDto
        {
            CategoryName = "Category 1",
            ImagePath = "/test.jpg"
        };

        // Act
        var result = await _productService.CreateCategoryAsync(createDto, default);

        // Assert
        _productCategoriesRepositoryMock.Verify(x => x.Add(It.IsAny<ProductCategory>()), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
        Assert.Equal(createDto.CategoryName, result.CategoryName);
    }

    [Fact]
    public async Task CreateSubCategoryAsync_ShouldCreateSubCategory()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var createDto = new CreateSubCategoryDto
        {
            SubCategoryName = "SubCat",
            ImagePath = "/test.jpg",
            CategoryId = categoryId
        };

        _productCategoriesRepositoryMock
            .Setup(x => x.GetAsync(categoryId, default))
            .ReturnsAsync(new ProductCategory { Id = categoryId });

        // Act
        var result = await _productService.CreateSubCategoryAsync(createDto, default);

        // Assert
        _productSubCategoriesRepositoryMock.Verify(x => x.Add(It.IsAny<ProductSubCategory>()), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
        Assert.Equal(createDto.SubCategoryName, result.SubCategoryName);
    }
}