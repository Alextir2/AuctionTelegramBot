using AuctionBot.Repository.Abstract;

namespace AuctionBot.Db.Models;

public class Category : EntityBase
{
    public IList<Product> Products { get; set; } = new List<Product>();
}