using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations;

public class ClientInfoConfiguration : IEntityTypeConfiguration<ClientInfo>
{
    public void Configure(EntityTypeBuilder<ClientInfo> builder)
    {
        builder.ToTable("Clients");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.LastName)
            .HasMaxLength(70)
            .IsRequired();
        
        builder.Property(c => c.FirstName)
            .HasMaxLength(70)
            .IsRequired();
        
        builder.Property(c => c.Patronymic)
            .HasMaxLength(70)
            .IsRequired();
        
        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(11)
            .IsRequired();
        
        builder.Property(c => c.Email)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.HasIndex(c => c.PhoneNumber)
            .IsUnique();
        
        builder.HasIndex(c => c.Email)
            .IsUnique();
        
        builder.HasMany(c => c.Orders)
            .WithOne(o => o.Client)
            .HasForeignKey(o => o.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}