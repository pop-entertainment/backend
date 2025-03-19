using Store.Domain.Entities;

namespace Store.Application.Repositories;

public interface IClientOrdersRepository
{
    Task<IEnumerable<ClientOrder>> GetAllAsync(CancellationToken cancellationToken);
    Task<ClientOrder> GetAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(ClientOrder clientOrder);
    void Update(ClientOrder clientOrder);
    void Remove(ClientOrder clientOrder);
}