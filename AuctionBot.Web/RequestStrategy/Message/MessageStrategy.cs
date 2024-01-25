using AuctionBot.Web.RequestStrategy.Check;
using AuctionBot.Web.RequestStrategy.Start;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.User;
using Microsoft.IdentityModel.Tokens;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AuctionBot.Web.RequestStrategy.Message;

public class MessageStrategy : IMessageStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IStartStrategy _startStrategy;
    
    private readonly ITelegramBotClient _telegramBotClient;

    private readonly ICheckStrategy _checkStrategy;

    private IUserRepository UserRepository => _unitOfWork.UserRepository;

    public MessageStrategy(
        IUnitOfWork unitOfWork, 
        ITelegramBotClient telegramBotClient,
        ICheckStrategy checkStrategy, 
        IStartStrategy startStrategy)
    {
        _unitOfWork = unitOfWork;
        _telegramBotClient = telegramBotClient;
        _checkStrategy = checkStrategy;
        _startStrategy = startStrategy;
    }

    public async Task Execute(Update update)
    {
        if (update.Message == null || (string.IsNullOrWhiteSpace(update.Message.Text) && update.Message.Photo.IsNullOrEmpty()) || update.Message?.Chat == null) 
            return;

        var command = update.Message?.Text?.ToLower();

        UserRepository.CheckUserByUpdateOrCreate(update);

        if (UserRepository.IsExistState(update.Message!.Chat.Id))
        {
            await _checkStrategy.Execute(update);
            return;
        }

        switch (command)
        {
            case not null when command.StartsWith(MessageCommands.Start) || command.StartsWith("/" + MessageCommands.Start):
            {
                await _startStrategy.Execute(update);
                break;
            }
            default:
            {
                await _telegramBotClient.SendTextMessageAsync(update.Message.Chat, "Введите корректную команду!");
                break;
            }
        }
    }
}