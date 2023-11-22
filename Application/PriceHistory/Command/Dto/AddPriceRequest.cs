using Application.Infrastructure;
using MediatR;

namespace Application.PriceHistory.Command;

public record AddPriceRequest(Guid productId, string price) : IRequest<Response>;