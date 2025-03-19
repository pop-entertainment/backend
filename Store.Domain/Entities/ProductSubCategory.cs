using System;
using System.Collections.Generic;
using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class ProductSubCategory : BaseEntity
{
    /// <summary>
    /// Название подкатегории
    /// </summary>
    public string SubCategoryName { get; set; }

    /// <summary>
    /// Путь к изображению подкатегории
    /// </summary>
    public string ImagePath { get; set; }

    public Guid CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public ICollection<ProductInfo> Products { get; set; }
}