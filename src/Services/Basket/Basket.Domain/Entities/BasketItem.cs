namespace Basket.Domain.Entities;

public class BasketItem : BaseEntity
{
    public Guid ProductId { get; private set; }
    
    public string ProductName { get; private set; }
    
    public int Quantity { get; private set; }
    
    public string Color { get; private set; }
    
    public decimal Price { get; private set; }

    public BasketItem(Guid id, Guid productId, string productName, int quantity, string color, decimal price) : base(id)
    {
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        Color = color;
        Price = price;
    }
}