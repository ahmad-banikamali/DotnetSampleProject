using Application.Infrastructure;
using AutoMapper;
using Repository.Infrastructure;

namespace Application.PriceHistory.Command;

public class AddPriceService : Command<AddPriceRequest>
{
    public AddPriceService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<Response> Handle(AddPriceRequest request, CancellationToken cancellationToken)
    {
        await UnitOfWork.PriceHistoryRepository.Insert(Mapper.Map<Domain.PriceHistory>(request));
        return new Response();
    }
}