using Application.Infrastructure;
using MediatR;

namespace Application.PriceHistory.Command.Dto;

public record AddPriceRequest(Guid productId, string price) : IRequest<Response>;