using System.Collections.Generic;

namespace Store.Data.Entities;

public class ProductCategory : BaseEntity
{
    public string CategoryName { get; set; }

    public string ImagePath { get; set; }

    public ICollection<ProductSubCategory> SubCategories { get; set; }

    public ICollection<ProductInfo> Products { get; set; }
}