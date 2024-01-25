using AuctionBot.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionBot.Db.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Name)
            .HasColumnType("varchar");
        
        builder.HasData(GetCategories());
    }

    private static IEnumerable<Category> GetCategories()
    {
        return new List<Category>
        {
            new()
            {
                Id = 1,
                Name = "Овощи",
                CreateDt = DateTime.UtcNow,
                UpdateDt = DateTime.UtcNow,
                IsDeleted = false
            },
            new()
            {
                Id = 2,
                Name = "Фрукты",
                CreateDt = DateTime.UtcNow,
                UpdateDt = DateTime.UtcNow,
                IsDeleted = false
            }
        };
    }
}