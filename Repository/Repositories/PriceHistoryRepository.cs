using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Infrastructure;
using Repository.IRepositories;

namespace Repository.Repositories;

public class PriceHistoryRepository<TContext> :GenericRepository<PriceHistory,TContext>, IPriceHistoryRepository where TContext:DbContext
{
    public PriceHistoryRepository(TContext context) : base(context)
    {
    }

    public Task<double> TotalPriceOverTime(DateOnly from, DateOnly to)
    { 
        throw new NotImplementedException();
    }
}