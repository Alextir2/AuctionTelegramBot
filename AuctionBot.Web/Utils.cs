using System.ComponentModel;
using AuctionBot.Repository;
using AuctionBot.Repository.Abstract;
using AuctionBot.Repository.GenericRepository;
using AuctionBot.Web.TgCommands;
using Microsoft.IdentityModel.Tokens;
using Telegram.Bot.Types.ReplyMarkups;

namespace AuctionBot.Web;

public static class Utils
{
    public static string GetDescription(this Enum value)
    {
        var type = value.GetType();
        var fieldInfo = type.GetField(value.ToString());
        var attribute = fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault();

        return attribute == null ? value.ToString() : ((DescriptionAttribute)attribute).Description;
    }

    public static IEnumerable<List<InlineKeyboardButton>> GenerateListButtons<TRepo, TEntity>(TRepo repo, int page)
        where TRepo : IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        var startButtonIndex = Math.Abs(page) * 4;

        var entities = repo.GetEntities().Actual().ToList();

        var repoName = repo.GetType().Name.Replace("Repository", string.Empty).ToLower();
        
        if (entities.IsNullOrEmpty()) return Enumerable.Empty<List<InlineKeyboardButton>>().ToList();

        var buttons = new List<List<InlineKeyboardButton>>();

        for (var i = startButtonIndex; i < startButtonIndex + 4; i++)
        {
            var entity = entities.Count > i ? entities.ElementAt(i) : null;

            if (entity == null) break;

            var button = new InlineKeyboardButton($"{entity.Name}")
            {
                CallbackData = $"/{repoName} - {entity.Id}"
            };

            buttons.Add(new List<InlineKeyboardButton> { button });
        }

        var nextPageButton = new InlineKeyboardButton("Следующая")
        {
            CallbackData = buttons.IsNullOrEmpty() ? $"/{CallbackQueryCommands.NextPage}-0" : $"/{CallbackQueryCommands.NextPage}-{page + 1}"
        };

        var lastPageButton = new InlineKeyboardButton("Предыдущая")
        {
            CallbackData = buttons.IsNullOrEmpty() ? $"/{CallbackQueryCommands.PreviousPage}-0" : $"/{CallbackQueryCommands.PreviousPage}-{page - 1}"
        };
        
        buttons.Add(new List<InlineKeyboardButton> { lastPageButton, nextPageButton });

        return buttons;
    }
}