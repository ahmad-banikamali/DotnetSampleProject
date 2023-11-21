using Repository.IRepositories;

namespace Repository.Infrastructure;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    IPriceHistoryRepository PriceHistoryRepository { get; }
    void CreateTransaction();

    void Commit();

    void Rollback();

    Task Save();
}