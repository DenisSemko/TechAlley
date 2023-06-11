namespace EventBus.Messages.Events;

public class BasketCheckoutEvent : IntegrationBaseEvent
{
    public Guid BuyerId { get; set; }
    public decimal TotalPrice { get; set; }
    public string ShippingMethod { get; set; }
    public string OrderStatus { get; set; }
}