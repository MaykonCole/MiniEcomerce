using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.ApiRepository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
               .ToTable("Users")
               .HasKey(u => u.Id);

            builder
               .Property(u => u.Name)
               .IsRequired()
               .HasColumnType("varchar(25)");

            builder
              .Property(u => u.Email)
              .IsRequired()
              .HasColumnType("varchar(50)");

            builder
              .Property(u => u.Name)
              .IsRequired()
              .HasColumnType("varchar(12)");
        }
    }
}
