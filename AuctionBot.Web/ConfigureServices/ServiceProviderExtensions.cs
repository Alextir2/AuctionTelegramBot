using AuctionBot.Db;
using AuctionBot.Web.Page;
using AuctionBot.Web.RequestStrategy.AddNewCategory;
using AuctionBot.Web.RequestStrategy.Buyer;
using AuctionBot.Web.RequestStrategy.CallbackQuery;
using AuctionBot.Web.RequestStrategy.Check;
using AuctionBot.Web.RequestStrategy.CheckAllCategories;
using AuctionBot.Web.RequestStrategy.ChooseCategory;
using AuctionBot.Web.RequestStrategy.ChooseFromList;
using AuctionBot.Web.RequestStrategy.CloseAuction;
using AuctionBot.Web.RequestStrategy.CreateAuction;
using AuctionBot.Web.RequestStrategy.CreateCategory;
using AuctionBot.Web.RequestStrategy.GetProductFromCategory;
using AuctionBot.Web.RequestStrategy.InsertPrice;
using AuctionBot.Web.RequestStrategy.Message;
using AuctionBot.Web.RequestStrategy.ProductAdd;
using AuctionBot.Web.RequestStrategy.ProductPhoto;
using AuctionBot.Web.RequestStrategy.ProductPrice;
using AuctionBot.Web.RequestStrategy.RaiseBid;
using AuctionBot.Web.RequestStrategy.Seller;
using AuctionBot.Web.RequestStrategy.Start;
using AuctionBot.Web.Services;
using AuctionBot.Web.Services.Payment;
using AuctionBot.Web.UoF;
using Telegram.Bot;

namespace AuctionBot.Web.ConfigureServices;

public static class ServiceProviderExtensions
{
    public static void ConfigureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddControllers();
        
        serviceCollection
            .AddEndpointsApiExplorer();
        
        serviceCollection
            .AddSwaggerGen();

        serviceCollection
            .AddDatabase(configuration);

        serviceCollection
            .AddScoped<IUnitOfWork, UnitOfWork>();

        serviceCollection
            .AddStrategy();
        
        serviceCollection
            .AddCustomServices();

        //todo: На время миграции закоментить этот код
        serviceCollection
            .AddTelegramBotClient(configuration);
    }
    
    private static void AddTelegramBotClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITelegramBotService, TelegramBotService>();
        
        var client = new TelegramBotClient(configuration["TelegramBotToken"]!);
        var webHook = $"{configuration["TelegramUrl"]!.Trim()}/api/telegram/message";
        client.SetWebhookAsync(webHook).Wait();

        services.AddSingleton<ITelegramBotClient>(client);
    }

    private static void AddStrategy(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IMessageStrategy, MessageStrategy>()
            .AddScoped<ICallbackQueryStrategy, CallbackQueryStrategy>()
            .AddScoped<IStartStrategy, StartStrategy>()
            .AddScoped<IBuyerStrategy, BuyerStrategy>()
            .AddScoped<IGetProductFromCategoryStrategy, GetProductFromCategoryStrategy>()
            .AddScoped<ICheckStrategy, CheckStrategy>()
            .AddScoped<IChooseFromListStrategy, ChooseFromListStrategy>()
            .AddScoped<ICheckAllCategoriesStrategy, CheckAllCategoriesStrategy>()
            .AddScoped<IChooseCategoryStrategy, ChooseCategoryStrategy>()
            .AddScoped<IAddNewCategoryStrategy, AddNewCategoryStrategy>()
            .AddScoped<ISellerStrategy, SellerStrategy>()
            .AddScoped<IProductAddStrategy, ProductAddStrategy>()
            .AddScoped<IProductPriceStrategy, ProductPriceStrategy>()
            .AddScoped<IProductPhotoStrategy, ProductPhotoStrategy>()
            .AddScoped<ICreateAuctionStrategy, CreateAuctionStrategy>()
            .AddScoped<ICreateCategoryStrategy, CreateCategoryStrategy>()
            .AddScoped<IRaiseBidStrategy, RaiseBidStrategy>()
            .AddScoped<IInsertPriceStrategy, InsertPriceStrategy>()
            .AddScoped<ICloseAuctionStrategy, CloseAuctionStrategy>();
    }
    
    private static void AddCustomServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IPaymentService, PaymentService>()
            .AddScoped<IPageGenerate, PageGenerate>();
    }
}