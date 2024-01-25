using AuctionBot.Repository.Interfaces;

namespace AuctionBot.Repository.Abstract;

public abstract class EntityBase : IEntity
{
    public int Id { get; init; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateDt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDt { get; set; } = DateTime.UtcNow;
}