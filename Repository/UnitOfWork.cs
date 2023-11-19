using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repository;

public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext
{
    private bool _disposed;
    private IDbContextTransaction _transaction;
    public TContext Context { get; }

    public UnitOfWork(TContext context)
    {
        Context = context;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    public void CreateTransaction()
    {
        _transaction = Context.Database.BeginTransaction();
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

    public void Save()
    {
        try
        {
            Context.SaveChanges();
        }
        catch (Exception e)
        {
            // ignored
        }
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                Context.Dispose();
        _disposed = true;
    }
}