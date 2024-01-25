using System.Linq.Expressions;
using AuctionBot.Db.Enums;
using AuctionBot.Repository;
using AuctionBot.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;

namespace AuctionBot.Web.UoF.User;

public class UserRepository : GenericRepository<Db.Models.User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
        
    }
    
    public bool IsExistState(long telegramUserChatId) => GetEntities(q => q.State).Actual().Any(q => q.TelegramUserChatId == telegramUserChatId && q.State != null);

    public void CheckUserByUpdateOrCreate(Update update)
    {
        var chatId = update.Message?.Chat.Id ?? update.CallbackQuery!.From.Id;
        var userName = update.Message?.Chat.Username ?? update.CallbackQuery!.From.Username!;
        
        var user = GetEntities().FirstOrDefault(q => q.TelegramUserChatId == chatId || q.Name == userName)
                   ?? new Db.Models.User();

        user.TelegramUserChatId = chatId;
        user.Name = userName;
        user.Role = Role.None;

        Insert(user);
        Save();
    }
}