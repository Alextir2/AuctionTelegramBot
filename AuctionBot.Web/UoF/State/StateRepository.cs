using AuctionBot.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace AuctionBot.Web.UoF.State;

public class StateRepository : GenericRepository<Db.Models.State>, IStateRepository
{
    public StateRepository(DbContext context) : base(context)
    {
    }
}