using AuctionBot.Db.Models;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Product;
using AuctionBot.Web.UoF.User;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy.ProductPrice;

public class ProductPriceStrategy : IProductPriceStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ITelegramBotClient _telegramBotClient;
    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    
    private IProductRepository ProductRepository => _unitOfWork.ProductRepository;

    public ProductPriceStrategy(IUnitOfWork unitOfWork, ITelegramBotClient telegramBotClient)
    {
        _unitOfWork = unitOfWork;
        _telegramBotClient = telegramBotClient;
    }

    public Task Execute(Update update)
    {
        var user = UserRepository.GetEntity( q=> q.TelegramUserChatId == update.Message!.Chat.Id, q=> q.State, q => q.Products);

        var product = user.Products.MaxBy(q => q.Id);

        if (product == null) return Task.CompletedTask;

        try
        {
            product.Price = Convert.ToDecimal(update.Message.Text);

            if (user.State == null)
                user.State = new State(StateCommands.AddPhotoProduct);
            else
                user.State.TelegramCommand = StateCommands.AddPhotoProduct;
            
            ProductRepository.Insert(product);
            UserRepository.Insert(user);
            
            _unitOfWork.Save();
            
            _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, "Отправьте 5 фотографий продукта:");
        }
        catch (Exception ex)
        {
            _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, ex.Message + "\nПример: 10,2");
        }
        
        return Task.CompletedTask;
    }
}