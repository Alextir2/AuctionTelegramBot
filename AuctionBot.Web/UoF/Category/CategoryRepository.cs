using AuctionBot.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace AuctionBot.Web.UoF.Category;

public class CategoryRepository : GenericRepository<Db.Models.Category>, ICategoryRepository
{
    public CategoryRepository(DbContext context) : base(context)
    {
    }
}