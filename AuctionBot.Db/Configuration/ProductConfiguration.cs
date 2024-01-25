using AuctionBot.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionBot.Db.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Name)
            .HasColumnType("varchar");
        
        builder.HasOne<Category>(q => q.Category)
            .WithMany(q => q.Products);
        
        builder.HasOne<User>(q => q.User)
            .WithMany(q => q.Products);

        builder.HasData(GetProducts());
    }

    private static IEnumerable<Product> GetProducts()
    {
        return new List<Product>
        {
            new()
            {
                Id = 1,
                CreateDt = DateTime.UtcNow,
                UpdateDt = DateTime.UtcNow,
                CategoryId = 1,
                UserId = 1,
                Name = "Огурцы",
                Price = 12
            },
            new()
            {
                Id = 2,
                CreateDt = DateTime.UtcNow,
                UpdateDt = DateTime.UtcNow,
                CategoryId = 2,
                UserId = 2,
                Name = "Абрикосы",
                Price = 10
            }
        };
    }
}