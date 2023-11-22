namespace Application.Product.Query.GetAllProducts.Dto;

public record GetAllProductsResponse(ICollection<ProductItem>? ProductList);