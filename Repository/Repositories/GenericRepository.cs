using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Infrastructure;
using Repository.IRepositories;

namespace Repository.Repositories;

public class GenericRepository<T,TContext> : IGenericRepository<T> where T : class where TContext: DbContext
{
    private readonly TContext _context;
    private readonly DbSet<T> _dbSet; 
    protected GenericRepository(TContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
 

    public async Task<T?> GetById(object id)
    {
        return await _dbSet.FindAsync(id);
    }


    public Task<List<T>> Get(Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "")
    {
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToListAsync() : query.ToListAsync();
        }
    }

    public async Task Insert(T obj)
    {
        await _dbSet.AddAsync(obj);
    }

    public Task Update(T obj)
    {
        if (_context.Entry(obj).State == EntityState.Detached)
            _dbSet.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public Task Delete(T obj)
    {
        if (_context.Entry(obj).State == EntityState.Detached)
        {
            _dbSet.Attach(obj);
        }
        _context.Entry(obj).State = EntityState.Deleted;
        return Task.CompletedTask;
    }
}