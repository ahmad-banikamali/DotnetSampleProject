using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.IRepositories;

namespace Repository.Infrastructure;

public class UnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
{
    private bool _disposed;
    private IDbContextTransaction _transaction;
    private readonly DbContext _dbContext;
    public IProductRepository ProductRepository { get; }
    public IPriceHistoryRepository PriceHistoryRepository { get; }

    public UnitOfWork(TContext context, IProductRepository productRepository,
        IPriceHistoryRepository priceHistoryRepository)
    {
        _dbContext = context;
        ProductRepository = productRepository;
        PriceHistoryRepository = priceHistoryRepository;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    public void CreateTransaction()
    {
        _transaction = _dbContext.Database.BeginTransaction();
    }

    public void Commit()
    {
        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Rollback();
        _transaction.Dispose();
    }

    public async Task Save()
    {
        try
        {
            var a = await _dbContext.SaveChangesAsync();
            Console.WriteLine($"hi {a}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _dbContext.Dispose();
        _disposed = true;
    }
}