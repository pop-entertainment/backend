using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Data;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }
    
    public DbSet<ClientInfo> Clients { get; set; }
    public DbSet<ClientOrder> ClientOrders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ProductInfo> Products { get; set; }
    public DbSet<ProductCategory> Categories { get; set; }
    public DbSet<ProductSubCategory> SubCategories { get; set; }
}