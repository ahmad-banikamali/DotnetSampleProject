using Microsoft.EntityFrameworkCore;

namespace Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
    protected DbSet<T> DbSet;

    public GenericRepository(IUnitOfWork<ApplicationDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
        DbSet = unitOfWork.Context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(object id)
    {
        throw new NotImplementedException();
    }

    public void Insert(T obj)
    {
        throw new NotImplementedException();
    }

    public void Update(T obj)
    {
        throw new NotImplementedException();
    }

    public void Delete(T obj)
    {
        throw new NotImplementedException();
    }
}