using AuctionBot.Web.TgCommands;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AuctionBot.Web.RequestStrategy.Start;

public class StartStrategy : IStartStrategy
{
    private readonly ITelegramBotClient _telegramBotClient;
    
    public StartStrategy(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public async Task Execute(Update update)
    {
        var keyboard = new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Покупатель", CallbackQueryCommands.Buyer),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Продавец", CallbackQueryCommands.Seller)
            }
        });

        await _telegramBotClient.SendTextMessageAsync(update.Message.Chat, "Выберите свою роль:",
            replyMarkup: keyboard);
    }
}