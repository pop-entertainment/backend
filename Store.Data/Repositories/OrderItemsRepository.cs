using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Application.Repositories;
using Store.Domain.Entities;

namespace Store.Data.Repositories;

public class OrderItemsRepository : IOrderItemsRepository
{
    private readonly DbSet<OrderItem> _dbSet;

    public OrderItemsRepository(StoreDbContext dataContext)
    {
        _dbSet = dataContext.Set<OrderItem>();
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
    
    public async Task<OrderItem> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Add(OrderItem orderItem)
    {
        _dbSet.Add(orderItem);
    }

    public void Update(OrderItem orderItem)
    {
        _dbSet.Update(orderItem);
    }

    public void Remove(OrderItem orderItem)
    {
        _dbSet.Remove(orderItem);
    }
}