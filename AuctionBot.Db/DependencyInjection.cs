using AuctionBot.Db.Context;
using AuctionBot.Db.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionBot.Db;

public static class DependencyInjection
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration
            .GetSection(nameof(DbOptions))
            .Get<DbOptions>();

        if (options == null)
            throw new InvalidOperationException("The connection string is missing in the project configuration.");

        services.AddDbContext<AuctionBotDbContext>(builder =>
            builder.UseNpgsql(options.ConnectionStringNpgSql));
    }
}