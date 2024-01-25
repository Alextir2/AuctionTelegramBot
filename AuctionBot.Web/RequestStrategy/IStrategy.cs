using Telegram.Bot.Types;

namespace AuctionBot.Web.RequestStrategy;

public interface IStrategy
{
    Task Execute(Update update);
}