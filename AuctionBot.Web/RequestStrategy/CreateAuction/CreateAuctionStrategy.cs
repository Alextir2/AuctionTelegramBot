using AuctionBot.Db.Models;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Auction;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy.CreateAuction;

public class CreateAuctionStrategy : ICreateAuctionStrategy
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITelegramBotClient _telegramBotClient;
    
    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    private IAuctionRepository AuctionRepository => _unitOfWork.AuctionRepository;
    
    public CreateAuctionStrategy(IUnitOfWork unitOfWork, ITelegramBotClient telegramBotClient)
    {
        _unitOfWork = unitOfWork;
        _telegramBotClient = telegramBotClient;
    }
    
    public Task Execute(Update update)
    {
        try
        {
            DateTime.TryParseExact(update.Message.Text,
                "dd.MM.yyyy HH:mm",
                null,
                System.Globalization.DateTimeStyles.AssumeLocal,
                out var endDt);

            if (endDt < DateTime.UtcNow)
            {
                _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, "Дата должна быть больше текущей!");
                return Task.CompletedTask;
            }
            
            var user = UserRepository.GetEntity(q => q.TelegramUserChatId == update.Message.Chat.Id, q => q.Products, q => q.State)!;

            var currentProduct = user.Products.MaxBy(q => q.CreateDt) ?? throw new Exception();

            var auction = new Auction
            {
                Product = currentProduct,
                Price = currentProduct.Price,
                EndDt = endDt.AddHours(3).ToUniversalTime(),
                Seller = user
            };

            user.State = null;
            
            UserRepository.Insert(user);
            
            AuctionRepository.Insert(auction);
            
            _unitOfWork.Save();

            _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, "Аукцион успешно создан!");
        }
        catch (Exception ex)
        {
            _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, ex.Message);
            throw;
        }
        
        return Task.CompletedTask;
    }
}