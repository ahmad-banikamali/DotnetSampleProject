using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository.IRepositories;

public interface IGenericRepository<T> where T : class
{ 
    Task<T?> GetById(object id);
    Task<List<T>> Get(Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = "");
    
    Task Insert(T obj);
    Task Update(T obj);
    Task Delete(T obj);
}