using Domain;

namespace Repository;

public interface IProductRepository
{
    Product GetByName(string name);
}