using AuctionBot.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace AuctionBot.Web.UoF.Auction;

public class AuctionRepository : GenericRepository<Db.Models.Auction>, IAuctionRepository
{
    public AuctionRepository(DbContext context) : base(context)
    {
    }
}