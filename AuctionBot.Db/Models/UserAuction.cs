using AuctionBot.Repository.Abstract;

namespace AuctionBot.Db.Models;

public class UserAuction : EntityBase
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int AuctionId { get; set; }
    public Auction Auction { get; set; }
}