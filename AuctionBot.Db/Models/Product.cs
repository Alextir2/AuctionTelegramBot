using AuctionBot.Repository.Abstract;

namespace AuctionBot.Db.Models;

public class Product : EntityBase
{
    public decimal Price { get; set; }
    
    public User User { get; set; }
    
    public int UserId { get; set; }
    
    public Category Category { get; set; }
    
    public int CategoryId { get; set; }

    public IList<Image> Images { get; set; } = new List<Image>();

    public IList<Auction> Auctions { get; set; } = new List<Auction>();
}