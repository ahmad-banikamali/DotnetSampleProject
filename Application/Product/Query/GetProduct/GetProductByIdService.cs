using Application.Common;
using Application.Infrastructure;
using Application.Product.Query.GetProduct.Dto;
using AutoMapper;
using Repository.Infrastructure;

namespace Application.Product.Query.GetProduct;

public class GetProductByIdService : Query<GetProductRequest, GetProductResponse>
{
    public GetProductByIdService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<Response<GetProductResponse>> Handle(
        GetProductRequest request,
        CancellationToken cancellationToken)
    {
        var product = await UnitOfWork.ProductRepository.GetById(request.Id);
        if (product == null)
            return new Response<GetProductResponse>(Message: "not found");

        var getProductResponse = Mapper.Map<GetProductResponse>(product);
        return new Response<GetProductResponse>(Data: getProductResponse);
    }
}