namespace Store.Application.DTOs.Category;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public string ImagePath { get; set; }
    public List<SubCategory.SubCategoryDto> SubCategories { get; set; } = new();
}