using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Application.Repositories;
using Store.Domain.Entities;

namespace Store.Data.Repositories;

public class ClientOrdersRepository : IClientOrdersRepository
{
    private readonly DbSet<ClientOrder> _dbSet;

    public ClientOrdersRepository(StoreDbContext dataContext)
    {
        _dbSet = dataContext.Set<ClientOrder>();
    }

    public async Task<IEnumerable<ClientOrder>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
    
    public async Task<ClientOrder> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Add(ClientOrder clientOrder)
    {
        clientOrder.Id = Guid.NewGuid();
        clientOrder.CreatedOn = DateTime.UtcNow;
        clientOrder.ModifiedOn = DateTime.UtcNow;
        _dbSet.Add(clientOrder);
    }

    public void Update(ClientOrder clientOrder)
    {
        clientOrder.ModifiedOn = DateTime.UtcNow;
        _dbSet.Update(clientOrder);
    }

    public void Remove(ClientOrder clientOrder)
    {
        _dbSet.Remove(clientOrder);
    }
}