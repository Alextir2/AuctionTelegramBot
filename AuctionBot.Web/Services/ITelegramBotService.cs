namespace AuctionBot.Web.Services;

public interface ITelegramBotService
{
    Task<object> HandleMessage(object upd);
}