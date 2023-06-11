namespace Ordering.Application.Features.Ordering.Queries.GetOrdersByBuyerId;

public class GetOrdersByBuyerIdQuery : IRequest<List<OrderDto>>
{
    public Guid BuyerId { get; set; }
}