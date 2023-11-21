using Application.Common;
using Application.Infrastructure;
using MediatR;

namespace Application.Product.Query.GetProduct;

public record GetProductRequest(Guid Guid) : IRequest<Response<Domain.Product>>;