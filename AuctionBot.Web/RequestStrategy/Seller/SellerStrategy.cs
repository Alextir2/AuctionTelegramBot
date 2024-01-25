using AuctionBot.Db.Enums;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AuctionBot.Web.RequestStrategy.Seller;

public class SellerStrategy : ISellerStrategy
{
    private readonly ITelegramBotClient _telegramBotClient;

    private readonly IUnitOfWork _unitOfWork;

    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    
    public SellerStrategy(ITelegramBotClient telegramBotClient, IUnitOfWork unitOfWork)
    {
        _telegramBotClient = telegramBotClient;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Update update)
    {
        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == update.CallbackQuery!.From.Id, q => q.State);

        
        user.Role = Role.Seller;

        UserRepository.Insert(user);

        _unitOfWork.Save();

        var keyboard = new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Просмотреть все категории", CallbackQueryCommands.CheckAllCategories),
            }
        });

        await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery!.From.Id,
            $"Ваша роль: {Role.Seller.GetDescription()}", replyMarkup: keyboard);
    }
}