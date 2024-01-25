using AuctionBot.Repository.GenericRepository;
using Telegram.Bot.Types;

namespace AuctionBot.Web.UoF.User;

public interface IUserRepository : IGenericRepository<Db.Models.User>
{
    void CheckUserByUpdateOrCreate(Update update);
    
    bool IsExistState(long telegramUserChatId);
}