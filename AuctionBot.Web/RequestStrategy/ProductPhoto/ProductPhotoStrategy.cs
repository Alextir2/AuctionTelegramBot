using AuctionBot.Db.Models;
using AuctionBot.Repository;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Product;
using AuctionBot.Web.UoF.User;
using Microsoft.IdentityModel.Tokens;
using Telegram.Bot;
using Telegram.Bot.Types;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using User = AuctionBot.Db.Models.User;

namespace AuctionBot.Web.RequestStrategy.ProductPhoto;

public class ProductPhotoStrategy : IProductPhotoStrategy
{
    private readonly IHostingEnvironment _environment;

    private readonly IUnitOfWork _unitOfWork;

    private readonly ITelegramBotClient _telegramBotClient;
    private IUserRepository UserRepository => _unitOfWork.UserRepository;

    private IProductRepository ProductRepository => _unitOfWork.ProductRepository;

    public ProductPhotoStrategy(IUnitOfWork unitOfWork, ITelegramBotClient telegramBotClient,
        IHostingEnvironment environment)
    {
        _unitOfWork = unitOfWork;
        _telegramBotClient = telegramBotClient;
        _environment = environment;
    }

    public Task Execute(Update update)
    {
        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == update.Message!.Chat.Id, q => q.State);

        if (user == null) return Task.CompletedTask;

        var product = ProductRepository.GetEntities(q => q.Images, q => q.Category)
            .Actual()
            .OrderByDescending(q => q.CreateDt)
            .FirstOrDefault(q => q.UserId == user.Id);

        if (product == null) return Task.CompletedTask;

        if (product.Images.Count >= 5)
        {
            _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId,
                "Вы уже отправили максимальное количество фотографий.");

            InsertDate(user);

            return Task.CompletedTask;
        }

        if (update.Message?.Photo == null || !update.Message.Photo.Any())
        {
            if (product.Images.IsNullOrEmpty())
            {
                _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, "Введите фото!");
                return Task.CompletedTask;
            }
        }

        if (string.IsNullOrWhiteSpace(_environment.WebRootPath))
        {
            _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        try
        {
            var photo = update.Message.Photo[^1];

            var fileId = photo.FileId;
            var file = _telegramBotClient.GetFileAsync(fileId).Result;

            var fileName = file.FilePath?.Split('/').Last();

            var uploadPath = Path.Combine(_environment.WebRootPath, "categories", $"{product.Category.Name}");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fullPath = Path.Combine(uploadPath, fileName);

            using var fileStream = new FileStream(fullPath, FileMode.Create);
            _telegramBotClient.DownloadFileAsync(file.FilePath, fileStream).Wait();

            product.Images.Add(new Image { Name = fileName });

            ProductRepository.Insert(product);
            _unitOfWork.Save();

            if (product.Images.Count == 5)
            {
                PhotoSuccessUpload(user);
                return Task.CompletedTask;
            }

            _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId,
                "Фотография успешно загружена. Осталось загрузить: " + (5 - product.Images.Count));
        }
        catch (Exception ex)
        {
            _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, ex.Message);
        }

        return Task.CompletedTask;
    }

    private void PhotoSuccessUpload(User user)
    {
        _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, "Все фотографии успешно загружены!");
        if (user.State != null)
        {
            user.State.TelegramCommand = StateCommands.CreateAuction;
            user.State.CategoryName = null;
        }
        else
            user.State = new State(StateCommands.CreateAuction);

        UserRepository.Insert(user);
        _unitOfWork.Save();

        InsertDate(user);
    }

    private void InsertDate(User user) => _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId,
        "Введите дату окончания аукциона в формате:\n25.05.2024 17:43");
}