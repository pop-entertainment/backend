using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Application.Repositories;
using Store.Domain.Entities;

namespace Store.Data.Repositories;

public class ClientsRepository : IClientsRepository
{
    private readonly DbSet<ClientInfo> _dbSet;

    public ClientsRepository(StoreDbContext dataContext)
    {
        _dbSet = dataContext.Set<ClientInfo>();
    }

    public async Task<IEnumerable<ClientInfo>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
    
    public async Task<ClientInfo> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Add(ClientInfo clientInfo)
    {
        _dbSet.Add(clientInfo);
    }

    public void Update(ClientInfo clientInfo)
    {
        _dbSet.Update(clientInfo);
    }

    public void Remove(ClientInfo clientInfo)
    {
        _dbSet.Remove(clientInfo);
    }
}