using Store.Domain.Entities;

namespace Store.Application.Repositories;

public interface IProductInfosRepository
{
    Task<IEnumerable<ProductInfo>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductInfo> GetAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(ProductInfo productInfo);
    void Update(ProductInfo productInfo);
    void Remove(ProductInfo productInfo);

    Task<IEnumerable<ProductInfo>> GetAllByCategoryIdAsync(Guid categoryId,
        CancellationToken cancellationToken);

    Task<IEnumerable<ProductInfo>> GetNewProductsAsync(int count, CancellationToken cancellationToken);
}