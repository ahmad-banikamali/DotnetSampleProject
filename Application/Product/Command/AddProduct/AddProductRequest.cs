using Application.Common;
using Application.Infrastructure;
using MediatR;

namespace Application.Product.Command.AddProduct;

public record AddProductRequest(string Name) : IRequest<Response>;