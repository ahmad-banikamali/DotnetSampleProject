using Application.Common;
using Application.Infrastructure;
using AutoMapper;
using Repository.Infrastructure;

namespace Application.Product.Query.GetProduct;

public class GetProductByIdService : Query< GetProductRequest, Domain.Product>
{
    public GetProductByIdService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override Task<Response<Domain.Product>> Handle(GetProductRequest request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(new Response<Domain.Product>(Data: default));
    }
}