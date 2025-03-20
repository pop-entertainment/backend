using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Application.Repositories;
using Store.Domain.Entities;

namespace Store.Data.Repositories;

public class ProductInfosRepository : IProductInfosRepository
{
    private readonly DbSet<ProductInfo> _dbSet;

    public ProductInfosRepository(StoreDbContext dataContext)
    {
        _dbSet = dataContext.Set<ProductInfo>();
    }

    public async Task<IEnumerable<ProductInfo>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
    
    public async Task<ProductInfo> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Add(ProductInfo productInfo)
    {
        _dbSet.Add(productInfo);
    }

    public void Update(ProductInfo productInfo)
    {
        _dbSet.Update(productInfo);
    }

    public void Remove(ProductInfo productInfo)
    {
        _dbSet.Remove(productInfo);
    }
}