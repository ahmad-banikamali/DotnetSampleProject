using Application.PriceHistory.Command;
using Application.PriceHistory.Query;
using AutoMapper;

namespace Application.Common.Mappers;

public class PriceHistoryMapper : Profile
{
    public PriceHistoryMapper()
    {
        CreateMap<AddPriceRequest, Domain.PriceHistory>().ForMember(x => x.Date,
            y => y.MapFrom(z => DateTime.Now));

        CreateMap<Domain.PriceHistory, PriceHistoryItem>().ForMember(x => x.ProductName, y =>
            y.MapFrom(z => z.Product.Name));
    }
}