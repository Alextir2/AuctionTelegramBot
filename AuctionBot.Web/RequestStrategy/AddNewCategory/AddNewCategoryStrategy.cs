using AuctionBot.Db.Models;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy.AddNewCategory;

public class AddNewCategoryStrategy : IAddNewCategoryStrategy
{
    private readonly ITelegramBotClient _telegramBotClient;

    private readonly IUnitOfWork _unitOfWork;
    
    private IUserRepository UserRepository => _unitOfWork.UserRepository;

    public AddNewCategoryStrategy(ITelegramBotClient telegramBotClient, IUnitOfWork unitOfWork)
    {
        _telegramBotClient = telegramBotClient;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(Update update)
    {
        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == update.CallbackQuery!.From.Id, q => q.State);
        
        if (user.State == null)
            user.State = new State(StateCommands.CreateCategory);
        else
            user.State.TelegramCommand = StateCommands.CreateCategory;

        UserRepository.Insert(user);

        _unitOfWork.Save();

        await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery!.From.Id, "Введите название новой категории:");
    }
}