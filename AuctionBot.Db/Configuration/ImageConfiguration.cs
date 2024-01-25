using AuctionBot.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionBot.Db.Configuration;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");

        builder.HasKey(q => q.Id);
        
        builder.Property(q => q.Name)
            .HasColumnType("varchar");

        builder.HasOne(q => q.Product)
            .WithMany(q => q.Images);
    }
}