namespace Basket.Application.Features.Basket.Commands.UpdateBasketItems;

//Command has IRequest<Basket> due to the API method it's been using
public class UpdateBasketItemsCommand : IRequest<Domain.Entities.Basket>
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public List<BasketItem> Items { get; set; }
    public int TotalItems { get; set; }
    public decimal TotalPrice { get; set; }
}