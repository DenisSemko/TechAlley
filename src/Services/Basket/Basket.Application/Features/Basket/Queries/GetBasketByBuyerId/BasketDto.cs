namespace Basket.Application.Features.Basket.Queries.GetBasketByBuyerId;

public class BasketDto
{
    public Guid Id { get; set;  }
    public Guid BuyerId { get; set; }
    public List<BasketItemDto> Items { get; set; }
    public int TotalItems { get; set; }
    public decimal TotalPrice { get; set; }
}