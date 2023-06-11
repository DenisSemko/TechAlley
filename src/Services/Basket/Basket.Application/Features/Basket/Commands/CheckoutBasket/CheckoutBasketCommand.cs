namespace Basket.Application.Features.Basket.Commands.CheckoutBasket;

public class CheckoutBasketCommand : IRequest<Unit>
{
    public Guid BuyerId { get; set; }
    public decimal TotalPrice { get; set; }

    public string ShippingMethod { get; set; }
    
    public string OrderStatus { get; set; }
}