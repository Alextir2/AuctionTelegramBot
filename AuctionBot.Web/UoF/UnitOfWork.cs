using AuctionBot.Db.Context;
using AuctionBot.Web.UoF.Auction;
using AuctionBot.Web.UoF.Category;
using AuctionBot.Web.UoF.Product;
using AuctionBot.Web.UoF.State;
using AuctionBot.Web.UoF.User;
using AuctionBot.Web.UoF.UserAuction;

namespace AuctionBot.Web.UoF;

public class UnitOfWork : IUnitOfWork
{
    private readonly AuctionBotDbContext _dbContext;

    public UnitOfWork(AuctionBotDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentException(null, nameof(dbContext));
        UserRepository = new UserRepository(dbContext);
        CategoryRepository = new CategoryRepository(dbContext);
        ProductRepository = new ProductRepository(dbContext);
        StateRepository = new StateRepository(dbContext);
        AuctionRepository = new AuctionRepository(dbContext);
        UserAuctionRepository = new UserAuctionRepository(dbContext);
    }

    #region Repositories
    
    public IUserRepository UserRepository { get; set; }
    public ICategoryRepository CategoryRepository { get; set; }
    public IProductRepository ProductRepository { get; set; }
    public IStateRepository StateRepository { get; set; }
    public IAuctionRepository AuctionRepository { get; set; }
    public IUserAuctionRepository UserAuctionRepository { get; set; }

    #endregion
    
    public void Dispose() => _dbContext.Dispose();

    public void Save() => _dbContext.SaveChanges();
}