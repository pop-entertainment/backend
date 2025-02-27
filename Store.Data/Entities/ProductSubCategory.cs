using System;
using System.Collections.Generic;

namespace Store.Data.Entities;

public class ProductSubCategory : BaseEntity
{
    public string SubCategoryName { get; set; }

    public string ImagePath { get; set; }

    public Guid CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public ICollection<ProductInfo> Products { get; set; }
}