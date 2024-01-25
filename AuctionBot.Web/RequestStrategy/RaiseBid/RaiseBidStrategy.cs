using AuctionBot.Db.Models;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Auction;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy.RaiseBid;

public class RaiseBidStrategy : IRaiseBidStrategy
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUnitOfWork _unitOfWork;

    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    private IAuctionRepository AuctionRepository => _unitOfWork.AuctionRepository;

    public RaiseBidStrategy(ITelegramBotClient telegramBotClient, IUnitOfWork unitOfWork)
    {
        _telegramBotClient = telegramBotClient;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Update update)
    {
        var chatId = update.Message?.Chat.Id ?? update.CallbackQuery?.From.Id;
        
        var command = update.CallbackQuery.Data.ToLower();
        
        var auctionStringId = command.Split('-', StringSplitOptions.RemoveEmptyEntries).Last();
        
        var isExistId = int.TryParse(auctionStringId, out var auctionId);

        if (!isExistId)
        {
            await _telegramBotClient.SendTextMessageAsync(chatId, "Аукцион не найден!");
            return;
        }

        var auction = AuctionRepository.GetEntity(q => q.Id == auctionId)!;

        if (auction.IsDeleted)
        {
            await _telegramBotClient.SendTextMessageAsync(chatId, "Аукцион удалён!");
            return;
        }
        
        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == chatId)!;

        if (user.State != null)
        {
            user.State.TelegramCommand = $"/{StateCommands.InsertPrice}- {auctionStringId}";
        }
        else
        {
            user.State = new State($"/{StateCommands.InsertPrice} - {auctionStringId}");
        }

        UserRepository.Insert(user);
        _unitOfWork.Save();
        
        await _telegramBotClient.SendTextMessageAsync(chatId, "Введите цену:");
    }
}