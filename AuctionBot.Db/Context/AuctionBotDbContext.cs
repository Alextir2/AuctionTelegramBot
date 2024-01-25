using AuctionBot.Db.Configuration;
using AuctionBot.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionBot.Db.Context;

public class AuctionBotDbContext : DbContext
{
    public AuctionBotDbContext(DbContextOptions<AuctionBotDbContext> options) : base(options) { }
    
    public virtual DbSet<User> Users { get; set; }
    
    public virtual DbSet<Product> Products { get; set; }
    
    public virtual DbSet<Category> Category { get; set; }
    
    public virtual DbSet<Image> Images { get; set; }
    
    public virtual DbSet<Auction> Auctions { get; set; }
    
    public virtual DbSet<UserAuction> UserAuction { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
        modelBuilder.ApplyConfiguration(new AuctionConfiguration());
        modelBuilder.ApplyConfiguration(new StateConfiguration());
        modelBuilder.ApplyConfiguration(new UserAuctionConfiguration());
    }
}