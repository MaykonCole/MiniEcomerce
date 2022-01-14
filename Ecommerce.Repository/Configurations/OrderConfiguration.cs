using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.ApiRepository.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Orders")
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
