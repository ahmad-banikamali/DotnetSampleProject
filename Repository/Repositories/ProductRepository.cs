using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Infrastructure;
using Repository.IRepositories;

namespace Repository.Repositories;

public class ProductRepository<TContext> : GenericRepository<Product,TContext>, IProductRepository where TContext : DbContext
{
    public ProductRepository(TContext context) : base(context)
    {
    }

    public Task<Product> GetByName(string name)
    {
        throw new NotImplementedException();
    }
}