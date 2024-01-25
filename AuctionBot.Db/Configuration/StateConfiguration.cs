using AuctionBot.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionBot.Db.Configuration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("States");

        builder.HasKey(q => q.Id);
        
        builder.Property(q => q.Name)
            .IsRequired(false)
            .HasDefaultValue("");
    }
}