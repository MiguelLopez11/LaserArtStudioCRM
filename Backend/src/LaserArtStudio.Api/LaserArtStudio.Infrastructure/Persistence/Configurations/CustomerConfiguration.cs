using LaserArtStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserArtStudio.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasIndex(x => x.Email)
                   .IsUnique();

            builder.Property(x => x.PhoneNumber)
                   .HasMaxLength(20);

            builder.Property(x => x.CreatedAt)
                   .IsRequired();

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);
        }

    }
}
