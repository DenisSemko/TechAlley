namespace Basket.Application.Features.Basket.Queries.GetBasketByBuyerId;

public class BasketItemDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
}