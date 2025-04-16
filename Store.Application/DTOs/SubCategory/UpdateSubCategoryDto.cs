namespace Store.Application.DTOs.SubCategory;

public class UpdateSubCategoryDto
{
    public string SubCategoryName { get; set; }
    public string ImagePath { get; set; }
    public Guid CategoryId { get; set; }
}