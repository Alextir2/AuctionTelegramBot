using AuctionBot.Repository;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Category;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AuctionBot.Web.RequestStrategy.CheckAllCategories;

public class CheckAllCategoriesStrategy : ICheckAllCategoriesStrategy
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUnitOfWork _unitOfWork;

    public CheckAllCategoriesStrategy(ITelegramBotClient telegramBotClient, IUnitOfWork unitOfWork)
    {
        _telegramBotClient = telegramBotClient;
        _unitOfWork = unitOfWork;
    }

    private ICategoryRepository CategoryRepository => _unitOfWork.CategoryRepository;

    public async Task Execute(Update update)
    {
        var keyboard = new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Выбрать категорию из списка", CallbackQueryCommands.ChooseCategory),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Создать новую категорию", CallbackQueryCommands.AddNewCategory)
            }
        });

        var categories = CategoryRepository.GetEntities().Actual().ToList();

        await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery!.From.Id,
            $"Список категорий:\n{string.Join("\n", categories.Select((category, index) => $"{index + 1}. {category.Name}"))}",
            replyMarkup: keyboard);
    }
}