using AuctionBot.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace AuctionBot.Web.UoF.UserAuction;

public class UserAuctionRepository : GenericRepository<Db.Models.UserAuction>, IUserAuctionRepository
{
    public UserAuctionRepository(DbContext context) : base(context)
    {
    }
}