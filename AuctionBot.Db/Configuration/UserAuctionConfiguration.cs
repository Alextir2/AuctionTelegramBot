using AuctionBot.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionBot.Db.Configuration;

public class UserAuctionConfiguration : IEntityTypeConfiguration<UserAuction>
{
    public void Configure(EntityTypeBuilder<UserAuction> builder)
    {
        builder.ToTable("UserAuctions");
        
        builder.HasKey(q => q.Id);

        builder.HasOne<User>(q => q.User)
            .WithMany(q => q.UserAuctions)
            .IsRequired(false);
        
        builder.HasOne<Auction>(q => q.Auction)
            .WithMany(q => q.UserAuctions)
            .IsRequired(false);
        
        builder.Property(q => q.Name)
            .IsRequired(false)
            .HasDefaultValue("");
    }
}