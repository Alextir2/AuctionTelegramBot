using AuctionBot.Db.Models;
using AuctionBot.Repository;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Category;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AuctionBot.Web.RequestStrategy.ChooseFromList;

public class ChooseFromListStrategy : IChooseFromListStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ITelegramBotClient _telegramBotClient;

    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    private ICategoryRepository CategoryRepository => _unitOfWork.CategoryRepository;

    public ChooseFromListStrategy(ITelegramBotClient telegramBotClient, IUnitOfWork unitOfWork)
    {
        _telegramBotClient = telegramBotClient;
        _unitOfWork = unitOfWork;
    }

    public Task Execute(Update update)
    {
        var text = update.Message!.Text!;

        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == update.Message!.Chat.Id, q => q.State)!;

        var category = CategoryRepository.GetEntities(q => q.Products).Actual().FirstOrDefault(q => q.Name == text);

        if (user.State == null)
            user.State = new State(StateCommands.AddProduct) { CategoryName = category?.Name };
        else
        {
            user.State.TelegramCommand = StateCommands.AddProduct;
            user.State.CategoryName = category?.Name;
        }

        if (category == null)
        {
            _telegramBotClient.SendTextMessageAsync(update.Message.Chat, "Такой категории не существует!");
            return Task.CompletedTask;
        }

        _telegramBotClient.SendTextMessageAsync(update.Message.Chat, "Введите название товара:");

        UserRepository.Insert(user);

        _unitOfWork.Save();

        return Task.CompletedTask;
    }
}