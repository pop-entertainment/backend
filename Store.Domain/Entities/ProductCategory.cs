using System.Collections.Generic;
using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class ProductCategory : BaseEntity
{
    /// <summary>
    /// Название категории
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Путь к изображению категории
    /// </summary>
    public string ImagePath { get; set; }

    public ICollection<ProductSubCategory> SubCategories { get; set; }

    public ICollection<ProductInfo> Products { get; set; }
}