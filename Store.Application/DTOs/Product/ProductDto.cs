using Store.Domain.Enums;

namespace Store.Application.DTOs.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public string Description { get; set; }
    public ProductStatus Status { get; set; }
    public string ImagePath { get; set; }
    public decimal Discount { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public Guid? SubCategoryId { get; set; }
    public string SubCategoryName { get; set; }
}