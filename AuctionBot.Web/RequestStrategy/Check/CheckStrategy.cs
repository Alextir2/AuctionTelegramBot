using AuctionBot.Web.RequestStrategy.ChooseFromList;
using AuctionBot.Web.RequestStrategy.CreateAuction;
using AuctionBot.Web.RequestStrategy.CreateCategory;
using AuctionBot.Web.RequestStrategy.InsertPrice;
using AuctionBot.Web.RequestStrategy.ProductAdd;
using AuctionBot.Web.RequestStrategy.ProductPhoto;
using AuctionBot.Web.RequestStrategy.ProductPrice;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.User;
using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy.Check;

public class CheckStrategy : ICheckStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IChooseFromListStrategy _chooseFromListStrategy;
    private readonly IProductAddStrategy _productAddStrategy;
    private readonly IProductPriceStrategy _productPriceStrategy;
    private readonly IProductPhotoStrategy _productPhotoStrategy;
    private readonly ICreateAuctionStrategy _createAuctionStrategy;
    private readonly ICreateCategoryStrategy _createCategoryStrategy;
    private readonly IInsertPriceStrategy _insertPriceStrategy;

    private IUserRepository UserRepository => _unitOfWork.UserRepository;

    public CheckStrategy(IUnitOfWork unitOfWork,
        IProductAddStrategy productAddStrategy, 
        IProductPriceStrategy productPriceStrategy, 
        IProductPhotoStrategy productPhotoStrategy, 
        ICreateAuctionStrategy createAuctionStrategy, 
        ICreateCategoryStrategy createCategoryStrategy, 
        IChooseFromListStrategy chooseFromListStrategy, 
        IInsertPriceStrategy insertPriceStrategy)
    {
        _unitOfWork = unitOfWork;
        _productAddStrategy = productAddStrategy;
        _productPriceStrategy = productPriceStrategy;
        _productPhotoStrategy = productPhotoStrategy;
        _createAuctionStrategy = createAuctionStrategy;
        _createCategoryStrategy = createCategoryStrategy;
        _chooseFromListStrategy = chooseFromListStrategy;
        _insertPriceStrategy = insertPriceStrategy;
    }

    public Task Execute(Update update)
    {
        var telegramChatId = update.Message!.Chat.Id;

        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == telegramChatId, q => q.State);

        var stateTelegramCommand = user.State.TelegramCommand;

        switch (stateTelegramCommand)
        {
            case not null when stateTelegramCommand.StartsWith(CheckCommands.ChooseFromList) || stateTelegramCommand.StartsWith("/" + CheckCommands.ChooseFromList):
            {
                _chooseFromListStrategy.Execute(update);
                break;
            }
            case not null when stateTelegramCommand.StartsWith(CheckCommands.AddProduct) || stateTelegramCommand.StartsWith("/" + CheckCommands.AddProduct):
            {
                _productAddStrategy.Execute(update);
                break;
            }
            case not null when stateTelegramCommand.StartsWith(CheckCommands.AddPriceProduct) || stateTelegramCommand.StartsWith("/" + CheckCommands.AddPriceProduct):
            {
                _productPriceStrategy.Execute(update);
                break;
            }
            case not null when stateTelegramCommand.StartsWith(CheckCommands.AddPhotoProduct) || stateTelegramCommand.StartsWith("/" + CheckCommands.AddPhotoProduct):
            {
                _productPhotoStrategy.Execute(update);
                break;
            }
            case not null when stateTelegramCommand.StartsWith(CheckCommands.CreateCategory) || stateTelegramCommand.StartsWith("/" + CheckCommands.CreateCategory):
            {
                _createCategoryStrategy.Execute(update);
                break;
            }
            case not null when stateTelegramCommand.StartsWith(CheckCommands.CreateAuction) || stateTelegramCommand.StartsWith("/" + CheckCommands.CreateAuction):
            {
                _createAuctionStrategy.Execute(update);
                break;
            }
            case not null when stateTelegramCommand.StartsWith(CheckCommands.InsertPrice) || stateTelegramCommand.StartsWith("/" + CheckCommands.InsertPrice):
            {
                _insertPriceStrategy.Execute(update);
                break;
            }
        }
        
        return Task.CompletedTask;
    }
}