using Application.Product.Command.AddProduct;
using Application.Product.Query.GetAllProducts.Dto;
using Application.Product.Query.GetProduct;
using Application.Product.Query.GetProduct.Dto;
using AutoMapper;

namespace Application.Common.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<AddProductRequest, Domain.Product>();
        CreateMap<Domain.Product, GetProductResponse>();
        CreateMap<Domain.Product, ProductItem>();
    }
}