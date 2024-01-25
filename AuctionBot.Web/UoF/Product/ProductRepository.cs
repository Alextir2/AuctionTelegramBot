using AuctionBot.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace AuctionBot.Web.UoF.Product;

public class ProductRepository : GenericRepository<Db.Models.Product>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context)
    {
        
    }
}