namespace Basket.Application.Features.Basket.Commands.DeleteBasket;

public class DeleteBasketCommand : IRequest
{
    public Guid BuyerId { get; set; }
}