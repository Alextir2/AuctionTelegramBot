using AuctionBot.Db.Enums;
using AuctionBot.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionBot.Db.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(q => q.Id);

        builder.HasData(GetUsers());
    }

    private static IEnumerable<User> GetUsers()
    {
        return new List<User>
        {
            new()
            {
                Id = 1,
                Name = "@edgerun",
                UpdateDt = DateTime.UtcNow,
                CreateDt = DateTime.UtcNow,
                TelegramUserChatId = 426772147,
                IsDeleted = false,
                Role = Role.Buyer
            },
            new()
            {
                Id = 2,
                Name = "@alextir2",
                UpdateDt = DateTime.UtcNow,
                CreateDt = DateTime.UtcNow,
                TelegramUserChatId = 1376808954,
                IsDeleted = false,
                Role = Role.Seller
            }
        };
    }
}