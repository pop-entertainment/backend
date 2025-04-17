using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Application.Repositories;
using Store.Domain.Entities;
using Store.Domain.Enums;

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
        var productInfos = await _dbSet.Where(p => p.Status != ProductStatus.OutStock).ToListAsync(cancellationToken);
        return productInfos;
    }
    
    public async Task<ProductInfo> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Add(ProductInfo productInfo)
    {
        productInfo.Id = Guid.NewGuid();
        productInfo.CreatedOn = DateTime.UtcNow;
        productInfo.ModifiedOn = DateTime.UtcNow;
        _dbSet.Add(productInfo);
    }

    public void Update(ProductInfo productInfo)
    {
        productInfo.ModifiedOn = DateTime.UtcNow;
        _dbSet.Update(productInfo);
    }

    public void Remove(ProductInfo productInfo)
    {
        _dbSet.Remove(productInfo);
    }
    
    public async Task<IEnumerable<ProductInfo>> GetAllByCategoryIdAsync(Guid subCategoryId,
        CancellationToken cancellationToken)
    {
        return await _dbSet.Where(p => p.SubCategoryId == subCategoryId || p.SubCategoryId == subCategoryId).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<ProductInfo>> GetNewProductsAsync(int count, CancellationToken cancellationToken)
    {
        return await _dbSet
            .OrderByDescending(p => p.CreatedOn)
            .Take(count)
            .ToListAsync(cancellationToken);
    }
}