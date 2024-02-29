using System;
using Core.Entites;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Count).IsRequired(true);
            builder.HasOne(x => x.Product).WithMany(x => x.Orders).HasForeignKey(x => x.ProductId);
        }
    }
}

