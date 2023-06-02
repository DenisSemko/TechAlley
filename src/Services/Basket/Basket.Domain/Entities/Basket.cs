namespace Basket.Domain.Entities;

public class Basket : BaseEntity
{
    public Guid BuyerId { get; private set; }
    public List<BasketItem> Items { get; set; } = new();
    public int TotalItems => Items.Sum(i => i.Quantity);
    public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);

    public Basket(Guid id, Guid buyerId) : base(id)
    {
        BuyerId = buyerId;
    }
}