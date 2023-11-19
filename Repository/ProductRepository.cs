using Domain;

namespace Repository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : base(unitOfWork)
    {
    }


    public Product GetByName(string name)
    {
        throw new NotImplementedException();
    }
}