namespace AuctionBot.Db.Options;

public class DbOptions
{
    public string ConnectionStringNpgSql { get; set; } = null!;
    
    public string ConnectionStringSqlServer { get; set; } = null!;
}