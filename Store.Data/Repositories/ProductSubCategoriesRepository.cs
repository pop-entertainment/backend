using System;
using System.Collections.Generic;
using System.Linq;
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
        subCategory.Id = Guid.NewGuid();
        subCategory.CreatedOn = DateTime.UtcNow;
        subCategory.ModifiedOn = DateTime.UtcNow;
        _dbSet.Add(subCategory);
    }

    public void Update(ProductSubCategory subCategory)
    {
        subCategory.ModifiedOn = DateTime.UtcNow;
        _dbSet.Update(subCategory);
    }

    public void Remove(ProductSubCategory subCategory)
    {
        _dbSet.Remove(subCategory);
    }

    public async Task<List<ProductSubCategory>> GetAllByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await _dbSet
            .Where(sub => sub.CategoryId == categoryId)
            .ToListAsync(cancellationToken);
    }
}