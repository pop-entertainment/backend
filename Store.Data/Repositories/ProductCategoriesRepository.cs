using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Application.Repositories;
using Store.Domain.Entities;

namespace Store.Data.Repositories;

public class ProductCategoriesRepository : IProductCategoriesRepository
{
    private readonly DbSet<ProductCategory> _dbSet;

    public ProductCategoriesRepository(StoreDbContext dataContext)
    {
        _dbSet = dataContext.Set<ProductCategory>();
    }

    public async Task<IEnumerable<ProductCategory>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
    
    public async Task<ProductCategory> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Add(ProductCategory productCategory)
    {
        productCategory.Id = Guid.NewGuid();
        productCategory.CreatedOn = DateTime.UtcNow;
        productCategory.ModifiedOn = DateTime.UtcNow;
        _dbSet.Add(productCategory);
    }

    public void Update(ProductCategory productCategory)
    {
        productCategory.ModifiedOn = DateTime.UtcNow;
        _dbSet.Update(productCategory);
    }

    public void Remove(ProductCategory productCategory)
    {
        _dbSet.Remove(productCategory);
    }
}