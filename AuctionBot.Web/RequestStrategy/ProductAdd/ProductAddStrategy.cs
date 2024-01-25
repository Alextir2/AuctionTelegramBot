using AuctionBot.Db.Models;
using AuctionBot.Repository;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Category;
using AuctionBot.Web.UoF.Product;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy.ProductAdd;

public class ProductAddStrategy : IProductAddStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ITelegramBotClient _telegramBotClient;
    
    private IUserRepository UserRepository => _unitOfWork.UserRepository;

    private ICategoryRepository CategoryRepository => _unitOfWork.CategoryRepository;

    private IProductRepository ProductRepository => _unitOfWork.ProductRepository;

    public ProductAddStrategy(IUnitOfWork unitOfWork, ITelegramBotClient telegramBotClient)
    {
        _unitOfWork = unitOfWork;
        _telegramBotClient = telegramBotClient;
    }
    
    public Task Execute(Update update)
    {
        var user = UserRepository.GetEntity( q=> q.TelegramUserChatId == update.Message!.Chat.Id);
        
        var category = CategoryRepository.GetEntities().Actual().FirstOrDefault(q => q.Name == user.State.CategoryName);

        var product = new Product
        {
            Name = update.Message.Text,
            User = user,
            Category = category,
            Price = 0
        };

        if (user.State == null)
            user.State = new State(StateCommands.AddPriceProduct);
        else
            user.State.TelegramCommand = StateCommands.AddPriceProduct;
        
        UserRepository.Insert(user);
        
        ProductRepository.Insert(product);
        
        _unitOfWork.Save();

        _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, "Введите минимальную цену товара:");
        
        return Task.CompletedTask;
    }
}