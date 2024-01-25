using AuctionBot.Repository.Abstract;

namespace AuctionBot.Db.Models;

public class State : EntityBase
{
    public State()
    {
    }

    public State(string telegramCommand)
    {
        TelegramCommand = telegramCommand;
    }

    public string? TelegramCommand { get; set; }
    
    public string? CategoryName { get; set; }
}