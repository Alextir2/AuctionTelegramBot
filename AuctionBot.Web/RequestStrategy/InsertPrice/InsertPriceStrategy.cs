using AuctionBot.Db.Models;
using AuctionBot.Web.TgCommands;
using AuctionBot.Web.UoF;
using AuctionBot.Web.UoF.Auction;
using AuctionBot.Web.UoF.User;
using AuctionBot.Web.UoF.UserAuction;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AuctionBot.Web.RequestStrategy.InsertPrice;

public class InsertPriceStrategy : IInsertPriceStrategy
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IUnitOfWork _unitOfWork;

    private IUserRepository UserRepository => _unitOfWork.UserRepository;
    private IAuctionRepository AuctionRepository => _unitOfWork.AuctionRepository;
    private IUserAuctionRepository UserAuctionRepository => _unitOfWork.UserAuctionRepository;

    public InsertPriceStrategy(ITelegramBotClient telegramBotClient, IUnitOfWork unitOfWork)
    {
        _telegramBotClient = telegramBotClient;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Update update)
    {
        var chatId = update.Message?.Chat.Id ?? update.CallbackQuery?.From.Id;

        var user = UserRepository.GetEntity(q => q.TelegramUserChatId == chatId, q => q.State)!;

        var auctionStringId = user.State!.TelegramCommand!.Split('-', StringSplitOptions.RemoveEmptyEntries).Last();

        var isCompleteAucId = int.TryParse(auctionStringId, out var auctionId);

        var isCompleteSum = decimal.TryParse(update.Message!.Text, out var sum);

        if (!isCompleteAucId || !isCompleteSum)
        {
            await _telegramBotClient.SendTextMessageAsync(chatId, "Не удалось обработать цену!");
            return;
        }

        var auction = AuctionRepository.GetEntity(q => q.Id == auctionId, q => q.UserAuctions, q => q.Product, q => q.Seller)!;

        if (auction.IsDeleted)
        {
            await _telegramBotClient.SendTextMessageAsync(chatId, "Аукцион завершён!");
            return;
        }
        
        var product = auction.Product;

        if (sum <= auction.Price)
        {
            await _telegramBotClient.SendTextMessageAsync(chatId, "Сумма должна быть больше текущей!");
            return;
        }

        auction.Price = sum;

        user.State = null;

        var userAuction = auction.UserAuctions!.FirstOrDefault(q => q.UserId == user.Id);
        
        if (userAuction == null)
        {
            userAuction = new UserAuction
            {
                Auction = auction,
                User = user
            };
        }
        else
        {
            userAuction.UpdateDt = DateTime.UtcNow;
        }

        UserAuctionRepository.Insert(userAuction);
        AuctionRepository.Insert(auction);
        UserRepository.Insert(user);
        _unitOfWork.Save();

        foreach (var item in auction.UserAuctions!)
        {
            var keyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Повысить ставку", $"/{CallbackQueryCommands.RaiseBid} - {auction.Id}")
                }
            });

            var follower = UserRepository.GetEntity(q => q.Id == item.UserId);

            _telegramBotClient.SendTextMessageAsync(follower.TelegramUserChatId,
                $"Сумма аукциона с товаром {product.Name} повысилась до {auction.Price} руб.!", replyMarkup: keyboard);
        }

        var closeKeyboard = new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Завершить аукцион", $"/{CallbackQueryCommands.CloseAuction} - {auction.Id}")
            }
        });

        await _telegramBotClient.SendTextMessageAsync(auction.Seller.TelegramUserChatId,
            $"Сумма аукциона с товаром {product.Name} повысилась до {auction.Price} руб.!", replyMarkup: closeKeyboard);
    }
}