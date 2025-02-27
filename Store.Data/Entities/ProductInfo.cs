using System;
using Store.Core.Models;

namespace Store.Data.Entities;

public class ProductInfo : BaseEntity
{
    public string Title { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public ProductStatus Status { get; set; }

    public string ImagePath { get; set; }
    
    //процент скидки
    public decimal Discount { get; set; }

    public Guid CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public Guid? SubCategoryId { get; set; }
    public ProductSubCategory SubCategory { get; set; }
}