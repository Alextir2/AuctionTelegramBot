using AuctionBot.Db.Models;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy.ChooseCategory;

public class ChooseCategoryStrategy : IChooseCategoryStrategy
{
    private readonly ITelegramBotClient _telegramBotClient;

    private readonly IUnitOfWork _unitOfWork;

    public ChooseCategoryStrategy(IUnitOfWork unitOfWork, ITelegramBotClient telegramBotClient)
    {
        _unitOfWork = unitOfWork;
        _telegramBotClient = telegramBotClient;
    }

    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    
    public async Task Execute(Update update)
    {
        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == update.CallbackQuery!.From.Id, q => q.State)!;
        
        if (user.State == null)
            user.State = new State(StateCommands.ChooseFromList);
        else
            user.State.TelegramCommand = StateCommands.ChooseFromList;

        UserRepository.Insert(user);
        _unitOfWork.Save();

        await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery!.From.Id,
            "Введите категорию из списка:");
    }
}