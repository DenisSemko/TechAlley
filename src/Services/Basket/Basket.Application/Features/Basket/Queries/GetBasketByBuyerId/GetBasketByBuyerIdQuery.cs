namespace Basket.Application.Features.Basket.Queries.GetBasketByBuyerId;

public class GetBasketByBuyerIdQuery : IRequest<BasketDto>
{
    public Guid BuyerId { get; set; }
}