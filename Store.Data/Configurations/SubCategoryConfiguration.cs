using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;

namespace Store.Data.Configurations;

public class SubCategoryConfiguration : IEntityTypeConfiguration<ProductSubCategory>
{
    public void Configure(EntityTypeBuilder<ProductSubCategory> builder)
    {
        builder.ToTable("SubCategories");
        
        builder.HasKey(psc => psc.Id);
        
        builder.Property(psc => psc.SubCategoryName)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.HasMany(psc => psc.Products)
            .WithOne(p => p.SubCategory)
            .HasForeignKey(p => p.SubCategoryId);
    }
}