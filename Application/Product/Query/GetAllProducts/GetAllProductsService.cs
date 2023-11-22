using Application.Infrastructure;
using Application.Product.Query.GetAllProducts.Dto;
using AutoMapper;
using Repository.Infrastructure;

namespace Application.Product.Query.GetAllProducts;

public class GetAllProductsService : Query<GetAllProductsRequest, GetAllProductsResponse>
{
    public GetAllProductsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<Response<GetAllProductsResponse>> Handle(GetAllProductsRequest request,
        CancellationToken cancellationToken)
    {
        var products = await UnitOfWork.ProductRepository.Get(orderBy: OrderBy);
        return new Response<GetAllProductsResponse>(
            Data: new GetAllProductsResponse(ProductList: Mapper.Map<List<ProductItem>>(products)));
    }

    private static IOrderedQueryable<Domain.Product> OrderBy(IQueryable<Domain.Product> arg)
    {
        return arg.OrderByDescending(product => product.Name);
    }
}