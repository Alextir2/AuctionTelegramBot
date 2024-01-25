using AuctionBot.Web.RequestStrategy;
using AuctionBot.Web.RequestStrategy.CallbackQuery;
using AuctionBot.Web.RequestStrategy.Message;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AuctionBot.Web.Services;

public class TelegramBotService : ITelegramBotService
{
    private readonly ITelegramBotClient _telegramBotClient;

    private readonly IMessageStrategy _messageStrategy;

    private readonly ICallbackQueryStrategy _callbackQueryStrategy;

    public TelegramBotService(ITelegramBotClient telegramBotClient, IMessageStrategy messageStrategy, ICallbackQueryStrategy callbackQueryStrategy)
    {
        _telegramBotClient = telegramBotClient;
        _messageStrategy = messageStrategy;
        _callbackQueryStrategy = callbackQueryStrategy;
    }

    public async Task<object> HandleMessage(object upd)
    {
        try
        {
            var update = JsonConvert.DeserializeObject<Update>(upd.ToString() ?? string.Empty);
            
            switch (update.Type)
            {
                case UpdateType.Message:
                {
                    await _messageStrategy.Execute(update);
                    break;
                }
                case UpdateType.CallbackQuery:
                {
                    await _callbackQueryStrategy.Execute(update);
                    break;
                }
                default:
                {
                    await _telegramBotClient.SendTextMessageAsync(update.Message?.Chat.Id, "Type of message not found");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            return Task.FromResult<object>("Произошла непредвиденная ошибка " + ex.Message);
        }

        return Task.FromResult<object>(null);
    }
}