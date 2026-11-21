using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.NewPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Id).IsRequired();
            builder.HasData(new Product { 
                Id = 1, Name = "Smartphone", Description = "Latest smartphone with advanced features", NewPrice = 699.99m, CategoryId = 1 },
                new Product { Id = 2, Name = "Laptop", Description = "High-performance laptop for work and gaming", NewPrice = 1299.99m, CategoryId = 1 },
                new Product { Id = 3, Name = "T-Shirt", Description = "Comfortable cotton t-shirt in various sizes", NewPrice = 19.99m, CategoryId = 2 },
                new Product { Id = 4, Name = "Jeans", Description = "Stylish denim jeans for casual wear", NewPrice = 49.99m, CategoryId = 2 },
                new Product { Id = 5, Name = "Novel", Description = "Bestselling fiction novel by a renowned author", NewPrice = 14.99m, CategoryId = 3 },
                new Product { Id = 6, Name = "Cookbook", Description = "Collection of delicious recipes for home cooking", NewPrice = 24.99m, CategoryId = 3 },
                new Product { Id = 7, Name = "Blender", Description = "Powerful blender for smoothies and food preparation", NewPrice = 89.99m, CategoryId = 4 },
                new Product { Id = 8, Name = "Vacuum Cleaner", Description = "Efficient vacuum cleaner for home cleaning", NewPrice = 149.99m, CategoryId = 4 },
                new Product { Id = 9, Name = "Yoga Mat", Description = "Non-slip yoga mat for exercise and meditation", NewPrice = 29.99m, CategoryId = 5 },
                new Product { Id = 10, Name = "Tent", Description = "Durable camping tent for outdoor adventures", NewPrice = 199.99m, CategoryId = 5 });
        }
       
    }
}
