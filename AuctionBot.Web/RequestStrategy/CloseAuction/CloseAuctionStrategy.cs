using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Auction;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy.CloseAuction;

public class CloseAuctionStrategy : ICloseAuctionStrategy
{
    
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUnitOfWork _unitOfWork;

    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    private IAuctionRepository AuctionRepository => _unitOfWork.AuctionRepository;
    
    public CloseAuctionStrategy(ITelegramBotClient telegramBotClient, IUnitOfWork unitOfWork)
    {
        _telegramBotClient = telegramBotClient;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(Update update)
    {
        var chatId = update.Message?.Chat.Id ?? update.CallbackQuery?.From.Id;

        var seller = UserRepository.GetEntity(q => q.TelegramUserChatId == chatId, q => q.State)!;
        
        var auctionStringId = update.CallbackQuery!.Data!.Split('-', StringSplitOptions.RemoveEmptyEntries).Last();

        int.TryParse(auctionStringId, out var auctionId);
        
        var auction = AuctionRepository.GetEntity(q => q.Id == auctionId, q => q.UserAuctions!, q => q.Seller, q=> q.Product)!;
        
        if (auction.IsDeleted)
        {
            await _telegramBotClient.SendTextMessageAsync(chatId, "Аукцион удалён!");
            return;
        }
        
        auction.UpdateDt = DateTime.UtcNow;
        auction.IsDeleted = true;

        AuctionRepository.Insert(auction);
        
        var buyerId = auction.UserAuctions!.MaxBy(q => q.UpdateDt)!.UserId;

        var buyer = UserRepository.GetEntity(q => q.Id == buyerId);
        
        var userIds = auction.UserAuctions!.Where(q => q.UserId != buyerId).Select(q => q.UserId );
        
        foreach (var userId in userIds)
        {
            var user = UserRepository.GetEntity(q => q.Id == userId, q=> q.State)!;

            user.State = null;
            
            _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, $"Аукцион с проудктом {auction.Product.Name} завершён!");
            
            UserRepository.Insert(user);
        }

        _unitOfWork.Save();

        await _telegramBotClient.SendTextMessageAsync(buyer.TelegramUserChatId, $"Поздравляем, аукцион завершён в вашу пользу, профиль продавца @{seller.Name}");
        
        await _telegramBotClient.SendTextMessageAsync(seller.TelegramUserChatId, $"Поздравляем, аукцион завершён, профиль покупателя @{buyer.Name}");
    }
}