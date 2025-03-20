using Store.Domain.Entities;

namespace Store.Application.Repositories;

public interface IOrderItemsRepository
{
    Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken);
    Task<OrderItem> GetAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(OrderItem orderItem);
    void Update(OrderItem orderItem);
    void Remove(OrderItem orderItem);
}