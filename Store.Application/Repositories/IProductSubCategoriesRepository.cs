using Store.Domain.Entities;

namespace Store.Application.Repositories;

public interface IProductSubCategoriesRepository
{
    Task<IEnumerable<ProductSubCategory>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductSubCategory> GetAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(ProductSubCategory subCategory);
    void Update(ProductSubCategory subCategory);
    void Remove(ProductSubCategory subCategory);
}