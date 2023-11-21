using Domain;

namespace Repository.IRepositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product> GetByName(string name);
}