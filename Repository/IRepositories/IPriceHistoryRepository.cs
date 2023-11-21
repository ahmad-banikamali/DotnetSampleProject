using Domain;

namespace Repository.IRepositories;

public interface IPriceHistoryRepository : IGenericRepository<PriceHistory>
{
    Task<double> TotalPriceOverTime(DateOnly from, DateOnly to);
}