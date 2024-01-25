namespace AuctionBot.Repository.Interfaces;

public interface IEntity
{
    public int Id { get; init; }
    public bool IsDeleted { get; set; }
    public DateTime CreateDt { get; set; }
    public DateTime UpdateDt { get; set; }
}