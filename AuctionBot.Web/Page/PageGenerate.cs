using AuctionBot.Db.Models;
using AuctionBot.Repository;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Category;
using AuctionBot.Web.UoF.User;
using Microsoft.IdentityModel.Tokens;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AuctionBot.Web.Page;

public class PageGenerate : IPageGenerate
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUnitOfWork _unitOfWork;

    private ICategoryRepository CategoryRepository => _unitOfWork.CategoryRepository;
    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    
    public PageGenerate(ITelegramBotClient telegramBotClient, IUnitOfWork unitOfWork)
    {
        _telegramBotClient = telegramBotClient;
        _unitOfWork = unitOfWork;
    }

    public async Task GeneratePage(Update update)
    {
        var command = update.CallbackQuery?.Data?.ToLower();

        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == update.CallbackQuery!.From.Id, q => q.State)!;
        
        try
        {
            var isExistPage = int.TryParse(command?.LastOrDefault().ToString(), out var page);

            if (!isExistPage) page = 0;
            
            var keyboard = new InlineKeyboardMarkup(Utils.GenerateListButtons<ICategoryRepository, Category>(CategoryRepository, page));
                    
            if (keyboard.InlineKeyboard.IsNullOrEmpty())
                await _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, "На данный момент аукционов не существует");
                    
            await DeleteLastMessageAsync(user.TelegramUserChatId, update.CallbackQuery!.Message!.MessageId);

            await _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, "Список категорий:", replyMarkup: keyboard);
        }
        catch (Exception e)
        {
            await _telegramBotClient.SendTextMessageAsync(user.TelegramUserChatId, "Ошибка при переходе на следущую страницу!");
            Console.WriteLine(e.Message);
            throw;
        }
    }
    
    private async Task DeleteLastMessageAsync(long chatId, int messageId)
    {
        try
        {
            await _telegramBotClient.DeleteMessageAsync(chatId, messageId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting message: {ex.Message}");
        }
    }
}