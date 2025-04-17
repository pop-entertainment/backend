using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.Category;
using Store.Application.Interfaces;

namespace Store.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IProductService _productService;

    public CategoryController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAllCategories")]
    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await _productService.GetAllCategoriesAsync(cancellationToken);
        return categories;
    }

    [HttpGet("GetCategory/{id}")]
    public async Task<CategoryDto> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _productService.GetCategoryAsync(id, cancellationToken);
        return category;
    }

    [HttpPost("CreateCategory")]
    public async Task<CategoryDto> CreateCategoryAsync([FromBody] CreateCategoryDto createCategoryDto, CancellationToken cancellationToken)
    {
        var category = await _productService.CreateCategoryAsync(createCategoryDto, cancellationToken);
        return category;
    }

    [HttpPut("UpdateCategory")]
    public async Task<CategoryDto> UpdateCategoryAsync(Guid id, [FromBody] UpdateCategoryDto updateCategoryDto,
        CancellationToken cancellationToken)
    {
        var category = await _productService.UpdateCategoryAsync(id, updateCategoryDto, cancellationToken);
        return category;
    }

    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        await _productService.DeleteCategoryAsync(id, cancellationToken);
        return StatusCode(StatusCodes.Status204NoContent);
    }
}