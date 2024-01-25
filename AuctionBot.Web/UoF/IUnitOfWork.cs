using AuctionBot.Web.UoF.Auction;
using AuctionBot.Web.UoF.Category;
using AuctionBot.Web.UoF.Product;
using AuctionBot.Web.UoF.State;
using AuctionBot.Web.UoF.User;
using AuctionBot.Web.UoF.UserAuction;

namespace AuctionBot.Web.UoF;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; set; }
    ICategoryRepository CategoryRepository { get; set; }
    IProductRepository ProductRepository { get; set; }
    IStateRepository StateRepository { get; set; }
    IAuctionRepository AuctionRepository { get; set; }
    IUserAuctionRepository UserAuctionRepository { get; set; }
    void Save();
}