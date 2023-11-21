namespace Domain;

public class PriceHistory 
{
    public Guid Id { get; init; }
    public DateTime Date { get; init; }
    public string Price { get; init; }
    public Guid ProductId { get; init; }
    public Product Product { get; init; }
}