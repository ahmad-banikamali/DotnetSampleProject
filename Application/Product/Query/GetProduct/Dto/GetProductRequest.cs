using Application.Infrastructure;
using MediatR;

namespace Application.Product.Query.GetProduct.Dto;

public record GetProductRequest(Guid Id) : IRequest<Response<GetProductResponse>>;