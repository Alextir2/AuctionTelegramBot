using AuctionBot.Db.Models;
using AuctionBot.Repository;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Category;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AuctionBot.Web.RequestStrategy.CreateCategory;

public class CreateCategoryStrategy : ICreateCategoryStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ITelegramBotClient _telegramBotClient;
    
    private ICategoryRepository CategoryRepository => _unitOfWork.CategoryRepository;
    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    
    public CreateCategoryStrategy(IUnitOfWork unitOfWork, ITelegramBotClient telegramBotClient)
    {
        _unitOfWork = unitOfWork;
        _telegramBotClient = telegramBotClient;
    }

    public Task Execute(Update update)
    {
        var category = new Category
        {
            Name = update.Message.Text
        };

        if (CategoryRepository.GetEntities().Actual().Any(q => q.Name == category.Name))
        {
            _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, "Такая категория уже существует!\nВведите другое название!");
            return Task.CompletedTask;
        }
        
        var chatId = update.Message?.Chat.Id ?? update.CallbackQuery?.From.Id;

        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == chatId)!;

        user.State = null;
        
        UserRepository.Insert(user);
        CategoryRepository.Insert(category);
        _unitOfWork.Save();
        
        _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, "Вы успешно создали категорию!");
        
        return Task.CompletedTask;
    }
}