namespace Basket.Domain.Entities;

public class BasketCheckout : BaseEntity
{
    public Guid BuyerId { get; set; }
    public decimal TotalPrice { get; set; }

    public BasketCheckout(Guid id, Guid buyerId, decimal totalPrice) : base(id)
    {
        BuyerId = buyerId;
        TotalPrice = totalPrice;
    }
}