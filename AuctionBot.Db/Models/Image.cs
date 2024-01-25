using AuctionBot.Repository.Abstract;

namespace AuctionBot.Db.Models;

public class Image : EntityBase
{
    public Product Product { get; set; }
}