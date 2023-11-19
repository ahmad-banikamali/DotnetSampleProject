using Microsoft.EntityFrameworkCore;

namespace Repository;

public interface IUnitOfWork<out TContext> where TContext : DbContext
{
    TContext Context { get; }

    void CreateTransaction();

    void Commit();

    void Rollback();

    void Save();
}