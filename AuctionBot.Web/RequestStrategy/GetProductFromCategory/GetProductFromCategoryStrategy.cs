using AuctionBot.Repository;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Product;
using AuctionBot.Web.UoF.User;
using Microsoft.IdentityModel.Tokens;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using File = System.IO.File;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace AuctionBot.Web.RequestStrategy.GetProductFromCategory;

public class GetProductFromCategoryStrategy : IGetProductFromCategoryStrategy
{
    private readonly IHostingEnvironment _environment;
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUnitOfWork _unitOfWork;

    private IProductRepository ProductRepository => _unitOfWork.ProductRepository;
    private IUserRepository UserRepository => _unitOfWork.UserRepository;

    public GetProductFromCategoryStrategy(IUnitOfWork unitOfWork, IHostingEnvironment environment,
        ITelegramBotClient telegramBotClient)
    {
        _unitOfWork = unitOfWork;
        _environment = environment;
        _telegramBotClient = telegramBotClient;
    }

    public async Task Execute(Update update)
    {
        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == update.CallbackQuery!.From.Id, q => q.State)!;

        var command = update.CallbackQuery!.Data!.ToLower();

        try
        {
            var categoryStringId = command.Split('-', StringSplitOptions.RemoveEmptyEntries).Last();

            var isExistId = int.TryParse(categoryStringId, out var categoryId);

            if (!isExistId)
            {
                await _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, "Категория не найдена!");
                return;
            }
            
            var products = ProductRepository
                .GetEntities(q => q.Images, q => q.Auctions, q => q.Category)
                .Actual()
                .Where(q => q.CategoryId == categoryId && !q.Auctions.Actual().IsNullOrEmpty())
                .ToList();

            if (products.IsNullOrEmpty())
            {
                await _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, "Аукционов по данной категории нет!");
                return;
            }

            await _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, "Список аукционов:");

            foreach (var product in products)
            {
                foreach (var auction in product.Auctions)
                {
                    var inputMedia = new List<IAlbumInputMedia>();

                    var i = 0;

                    try
                    {
                        foreach (var photoName in product.Images.Select(q => q.Name).Take(5))
                        {
                            var filePath = _environment.WebRootPath + $@"\categories\{product.Category.Name}\{photoName}";
                            var fileName = Path.GetFileName(filePath);
                            var fileBytes = await File.ReadAllBytesAsync(filePath);
                        
                            inputMedia.Add(new InputMediaPhoto(new InputFileStream(new MemoryStream(fileBytes), fileName)) { Caption = $"{++i}" });
                        }

                        await _telegramBotClient.SendMediaGroupAsync(user.TelegramUserChatId, inputMedia);
                    }
                    catch (Exception e)
                    {
                        await _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, $"Не найдены фото для аукциона с продуктом \"{auction.Product.Name}\"");
                        Console.WriteLine(e.Message + $" AuctionId {auction.Id}");
                    }

                    var description = $"Название: {product.Name}\nЦена: {auction.Price} руб.\nДата окончания аукциона: {auction.EndDt}";

                    var keyboard = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Повысить ставку", $"/{CallbackQueryCommands.RaiseBid} - {auction.Id}")
                        }
                    });

                    await _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, description, replyMarkup: keyboard);
                }
            }
        }
        catch (Exception e)
        {
            await _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, "Ошибка отправки файлов!\n" + e.Message);
            throw;
        }
    }
}