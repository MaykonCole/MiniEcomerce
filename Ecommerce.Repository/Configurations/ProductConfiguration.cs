using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.ApiRepository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("Products")
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(25)");

            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
               .Property(p => p.InStock)
               .IsRequired()
               .HasColumnType("int");

            builder
               .Property(p => p.Details)
               .HasColumnType("varchar(50)");
        }
    }
}
