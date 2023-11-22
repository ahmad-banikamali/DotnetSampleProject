using Application.Infrastructure;
using AutoMapper;
using MediatR;
using Repository.Infrastructure;

namespace Application.PriceHistory.Query;

public record GetAllPricesRequest(Guid ProductId) : IRequest<Response<GetAllPricesResponse>>;

public class GetAllPricesService : Query<GetAllPricesRequest, GetAllPricesResponse>
{
    public GetAllPricesService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<Response<GetAllPricesResponse>> Handle(GetAllPricesRequest request,
        CancellationToken cancellationToken)
    {
        var priceHistories =
            await UnitOfWork.PriceHistoryRepository.Get(
                filter: history => history.ProductId == request.ProductId,
                includeProperties: nameof(Domain.PriceHistory.Product));

        return new Response<GetAllPricesResponse>(
            new GetAllPricesResponse(Mapper.Map<ICollection<PriceHistoryItem>>(priceHistories)));
    }
}

public record PriceHistoryItem(string ProductName, string Price, DateTime Date);

public record GetAllPricesResponse(ICollection<PriceHistoryItem> PriceHistoryItems);