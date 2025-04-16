using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.Product;
using Store.Application.Interfaces;

namespace Store.Web.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    /// <summary>
    /// Возвращает products, которые не outStock
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetAllProducts")]
    public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllProductsAsync(cancellationToken);
        return products;
    }

    [HttpGet("GetProduct/{id}")]
    public async Task<ProductDto> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductAsync(id, cancellationToken);
        return product;
    }

    [HttpPost("CreateProduct")]
    public async Task<ProductDto> CreateProductAsync([FromBody] CreateProductDto productDto, CancellationToken cancellationToken)
    {
        var product = await _productService.CreateProductAsync(productDto, cancellationToken);
        return product;
    }

    [HttpPut("UpdateProduct/{id}")]
    public async Task<ProductDto> UpdateProductAsync(Guid id, [FromBody] UpdateProductDto productDto, CancellationToken cancellationToken)
    {
        var product = await _productService.UpdateProductAsync(id, productDto, cancellationToken);
        return product;
    }

    [HttpDelete("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProductAsync(Guid id, CancellationToken cancellationToken)
    {
        await _productService.DeleteProductAsync(id, cancellationToken);
        return StatusCode(StatusCodes.Status204NoContent);
    }

    /// <summary>
    /// Возвращает products по categoryId или subCategoryId
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>ProductDto list</returns>
    [HttpGet("GetProductsByCategoryId/{id}")]
    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var products = await _productService.GetProductsByCategoryId(id, cancellationToken);
        return products;
    }

    /// <summary>
    /// Возвращает 10 последние добавленных products
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>ProductDto list</returns>
    [HttpGet("GetNewPopularProducts")]
    public async Task<IEnumerable<ProductDto>> GetNewPopularProductsAsync(CancellationToken cancellationToken)
    {
        var products = await _productService.GetNewPopularProductsAsync(cancellationToken);
        return products;
    }
}