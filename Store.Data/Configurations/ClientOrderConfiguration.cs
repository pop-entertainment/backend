using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations;

public class ClientOrderConfiguration : IEntityTypeConfiguration<ClientOrder>
{
    public void Configure(EntityTypeBuilder<ClientOrder> builder)
    {
        builder.ToTable("ClientOrders");
        
        builder.HasKey(o => o.Id);

        builder.Property(o => o.OrderDate)
            .IsRequired();
        
        builder.Property(o => o.TotalAmount)
            .IsRequired();
        
        builder.HasMany(o => o.OrderItems)
            .WithOne(oi => oi.ClientOrder)
            .HasForeignKey(oi => oi.ClientOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}