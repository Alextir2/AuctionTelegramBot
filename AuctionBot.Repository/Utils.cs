using AuctionBot.Repository.Abstract;
using AuctionBot.Repository.Interfaces;

namespace AuctionBot.Repository;

public static class Utils
{
    public static IEnumerable<T> Actual<T>(this IEnumerable<T> enumerable) where T : IEntity =>
        enumerable.Where(q => !q.IsDeleted);

    public static IEnumerable<T> Archive<T>(this IEnumerable<T> enumerable) where T : EntityBase =>
        enumerable.Where(q => q.IsDeleted);

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<EntityBase> action)
        where T : EntityBase
    {
        foreach (var item in enumerable)
        {
            action(item);
        }

        return enumerable;
    }
}