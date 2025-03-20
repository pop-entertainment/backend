using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Application.Repositories;
using Store.Domain.Entities;

namespace Store.Data.Repositories;

public class ProductSubCategoriesRepository : IProductSubCategoriesRepository
{
    private readonly DbSet<ProductSubCategory> _dbSet;

    public ProductSubCategoriesRepository(StoreDbContext dataContext)
    {
        _dbSet = dataContext.Set<ProductSubCategory>();
    }

    public async Task<IEnumerable<ProductSubCategory>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
    
    public async Task<ProductSubCategory> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Add(ProductSubCategory subCategory)
    {
        _dbSet.Add(subCategory);
    }

    public void Update(ProductSubCategory subCategory)
    {
        _dbSet.Update(subCategory);
    }

    public void Remove(ProductSubCategory subCategory)
    {
        _dbSet.Remove(subCategory);
    }
}