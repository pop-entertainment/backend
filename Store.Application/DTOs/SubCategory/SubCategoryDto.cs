namespace Store.Application.DTOs.SubCategory;

public class SubCategoryDto
{
    public Guid Id { get; set; }
    public string SubCategoryName { get; set; }
    public string ImagePath { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
}