using Store.Domain.Entities;

namespace Store.Application.Repositories;

public interface IClientsRepository
{
    Task<IEnumerable<ClientInfo>> GetAllAsync(CancellationToken cancellationToken);
    Task<ClientInfo> GetAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(ClientInfo clientInfo);
    void Update(ClientInfo clientInfo);
    void Remove(ClientInfo clientInfo);
}