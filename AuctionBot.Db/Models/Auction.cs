using AuctionBot.Repository.Abstract;

namespace AuctionBot.Db.Models;

public class Auction : EntityBase
{
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    public User Seller { get; set; }
    
    public int SellerId { get; set; }

    public List<UserAuction>? UserAuctions { get; set; } = new();
    
    public decimal Price { get; set; }
    
    public DateTime EndDt { get; set; }
}