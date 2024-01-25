using AuctionBot.Db.Enums;
using AuctionBot.Repository.Abstract;

namespace AuctionBot.Db.Models;

public class User : EntityBase
{
    public long TelegramUserChatId { get; set; }
    
    public Role? Role { get; set; }

    public State? State { get; set; }
    
    public IList<Product> Products { get; set; } = new List<Product>();
    
    public List<UserAuction>? UserAuctions { get; set; } = new();
}