using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.SubCategory;
using Store.Application.Interfaces;

namespace Store.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCategoryController : ControllerBase
{
    private readonly IProductService _productService;

    public SubCategoryController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAllSubCategories")]
    public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync(CancellationToken cancellationToken)
    {
        var subCategories = await _productService.GetAllSubCategoriesAsync(cancellationToken);
        return subCategories;
    }

    [HttpGet("GetSubCategory/{id}")]
    public async Task<SubCategoryDto> GetSubCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        var subCategory = await _productService.GetSubCategoryAsync(id, cancellationToken);
        return subCategory;
    }

    [HttpPost("CreateSubCategory")]
    public async Task<SubCategoryDto> AddSubCategoryAsync([FromBody] CreateSubCategoryDto createSubCategoryDto,
        CancellationToken cancellationToken)
    {
        var subCategory = await _productService.CreateSubCategoryAsync(createSubCategoryDto, cancellationToken);
        return subCategory;
    }

    [HttpPut("UpdateSubCategory/{id}")]
    public async Task<SubCategoryDto> UpdateSubCategory(Guid id, [FromBody] UpdateSubCategoryDto updateSubCategoryDto,
        CancellationToken cancellationToken)
    {
        var subCategory = await _productService.UpdateSubCategoryAsync(id, updateSubCategoryDto, cancellationToken);
        return subCategory;
    }

    [HttpDelete("DeleteSubCategory/{id}")]
    public async Task<IActionResult> DeleteSubCategory(Guid id, CancellationToken cancellationToken)
    {
        await _productService.DeleteSubCategoryAsync(id, cancellationToken);
        return StatusCode(StatusCodes.Status204NoContent);
    }

    /// <summary>
    /// Возвращает подкатегории по id категории
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>SubCategoryDto list</returns>
    [HttpGet("GetAllSubCategoryByCategoryId/{id}")]
    public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoryByCategoryIdAsync([FromQuery] Guid id,
        CancellationToken cancellationToken)
    {
        var subCategories = await _productService.GetAllSubCategoriesByCategoryIdAsync(id, cancellationToken);
        return subCategories;
    }
}