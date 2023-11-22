using Application.Infrastructure;
using MediatR;

namespace Application.Product.Query.GetAllProducts.Dto;

public record GetAllProductsRequest : IRequest<Response<GetAllProductsResponse>>;