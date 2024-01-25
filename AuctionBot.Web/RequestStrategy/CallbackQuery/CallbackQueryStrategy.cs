using AuctionBot.Web.Page;
using AuctionBot.Web.RequestStrategy.AddNewCategory;
using AuctionBot.Web.RequestStrategy.Buyer;
using AuctionBot.Web.RequestStrategy.CheckAllCategories;
using AuctionBot.Web.RequestStrategy.ChooseCategory;
using AuctionBot.Web.RequestStrategy.CloseAuction;
using AuctionBot.Web.RequestStrategy.GetProductFromCategory;
using AuctionBot.Web.RequestStrategy.RaiseBid;
using AuctionBot.Web.RequestStrategy.Seller;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy.CallbackQuery;

public class CallbackQueryStrategy : ICallbackQueryStrategy
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IBuyerStrategy _buyerStrategy;
    private readonly IGetProductFromCategoryStrategy _getProductFromCategoryStrategy;
    private readonly ICheckAllCategoriesStrategy _checkAllCategoriesStrategy;
    private readonly IChooseCategoryStrategy _chooseCategoryStrategy;
    private readonly ISellerStrategy _sellerStrategy;
    private readonly IAddNewCategoryStrategy _addNewCategoryStrategy;
    private readonly IRaiseBidStrategy _raiseBidStrategy;
    private readonly ICloseAuctionStrategy _closeAuctionStrategy;
    private readonly IPageGenerate _pageGenerate;

    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    
    public CallbackQueryStrategy(IBuyerStrategy buyerStrategy,
        IGetProductFromCategoryStrategy getProductFromCategoryStrategy,
        ICheckAllCategoriesStrategy checkAllCategoriesStrategy, IChooseCategoryStrategy chooseCategoryStrategy,
        ISellerStrategy sellerStrategy, IAddNewCategoryStrategy addNewCategoryStrategy,
        IRaiseBidStrategy raiseBidStrategy, ICloseAuctionStrategy closeAuctionStrategy, IPageGenerate pageGenerate,
        ITelegramBotClient telegramBotClient, IUnitOfWork unitOfWork)
    {
        _buyerStrategy = buyerStrategy;
        _getProductFromCategoryStrategy = getProductFromCategoryStrategy;
        _checkAllCategoriesStrategy = checkAllCategoriesStrategy;
        _chooseCategoryStrategy = chooseCategoryStrategy;
        _sellerStrategy = sellerStrategy;
        _addNewCategoryStrategy = addNewCategoryStrategy;
        _raiseBidStrategy = raiseBidStrategy;
        _closeAuctionStrategy = closeAuctionStrategy;
        _pageGenerate = pageGenerate;
        _telegramBotClient = telegramBotClient;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Update update)
    {
        if (update.CallbackQuery == null || string.IsNullOrWhiteSpace(update.CallbackQuery.Data)) return;

        var command = update.CallbackQuery.Data.ToLower();

        UserRepository.CheckUserByUpdateOrCreate(update);
        
        if (string.IsNullOrWhiteSpace(command))
            await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Команда не найдена!");

        switch (command)
        {
            case not null when command.StartsWith(CallbackQueryCommands.Buyer) ||
                               command.StartsWith("/" + CallbackQueryCommands.Buyer):
            {
                await _buyerStrategy.Execute(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.GetCategories) ||
                               command.StartsWith("/" + CallbackQueryCommands.GetCategories):
            {
                await _pageGenerate.GeneratePage(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.NextPage) ||
                               command.StartsWith("/" + CallbackQueryCommands.NextPage):
            {
                await _pageGenerate.GeneratePage(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.PreviousPage) ||
                               command.StartsWith("/" + CallbackQueryCommands.PreviousPage):
            {
                await _pageGenerate.GeneratePage(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.GetProductFromCategory) ||
                               command.StartsWith("/" + CallbackQueryCommands.GetProductFromCategory):
            {
                await _getProductFromCategoryStrategy.Execute(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.Seller) ||
                               command.StartsWith("/" + CallbackQueryCommands.Seller):
            {
                await _sellerStrategy.Execute(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.CheckAllCategories) ||
                               command.StartsWith("/" + CallbackQueryCommands.CheckAllCategories):
            {
                await _checkAllCategoriesStrategy.Execute(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.ChooseCategory) ||
                               command.StartsWith("/" + CallbackQueryCommands.ChooseCategory):
            {
                await _chooseCategoryStrategy.Execute(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.AddNewCategory) ||
                               command.StartsWith("/" + CallbackQueryCommands.AddNewCategory):
            {
                await _addNewCategoryStrategy.Execute(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.RaiseBid) ||
                               command.StartsWith("/" + CallbackQueryCommands.RaiseBid):
            {
                await _raiseBidStrategy.Execute(update);
                break;
            }
            case not null when command.StartsWith(CallbackQueryCommands.CloseAuction) ||
                               command.StartsWith("/" + CallbackQueryCommands.CloseAuction):
            {
                await _closeAuctionStrategy.Execute(update);
                break;
            }
        }
    }
}