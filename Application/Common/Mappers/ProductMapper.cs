using Application.Product.Command.AddProduct;
using AutoMapper;

namespace Application.Common.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<AddProductRequest, Domain.Product>();
    }
}