using Telegram.Bot.Types;

namespace AuctionBot.Web.Page;

public interface IPageGenerate
{
    Task GeneratePage(Update update);
}