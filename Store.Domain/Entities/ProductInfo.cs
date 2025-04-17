using System;
using Store.Domain.Abstractions;
using Store.Domain.Enums;

namespace Store.Domain.Entities;

public class ProductInfo : BaseEntity
{
    /// <summary>
    /// Название товара
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Статус товара
    /// </summary>
    public ProductStatus Status { get; set; }

    /// <summary>
    /// Путь к изображению товара
    /// </summary>
    public string ImagePath { get; set; }

    /// <summary>
    /// Процент скидки
    /// </summary>
    public decimal Discount { get; set; }
    
    /// <summary>
    /// Количество товара
    /// </summary>
    public int Quantity { get; set; }

    public Guid CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public Guid? SubCategoryId { get; set; }
    public ProductSubCategory SubCategory { get; set; }
}