using Store.Domain.Entities;

namespace Store.Application.Repositories;

public interface IProductCategoriesRepository
{
    Task<IEnumerable<ProductCategory>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductCategory> GetAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(ProductCategory productCategory);
    void Update(ProductCategory productCategory);
    void Remove(ProductCategory productCategory);
}