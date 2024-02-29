using System;
using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
	public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(25);

            builder.HasOne(x => x.Brand).WithMany(x=>x.Products).HasForeignKey(x => x.BrandId);
        }
    }
}
