using AuctionBot.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionBot.Db.Configuration;

public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
{
    public void Configure(EntityTypeBuilder<Auction> builder)
    {
        builder
            .ToTable("Auctions");
        
        builder.HasKey(q => q.Id);

        builder.HasOne(q => q.Product);
        
        builder.HasOne<User>(q => q.Seller);

        builder.Property(q => q.Name)
            .IsRequired(false)
            .HasDefaultValue("");
    }
}