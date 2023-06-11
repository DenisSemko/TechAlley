namespace Ordering.Domain.Entities;

// It's not inherited from the BaseEntity due to the issues with ValueObjects and EF Core
public class Order
{
    public Guid Id { get; private set; }
    public Guid BuyerId { get; private set; }
    public decimal TotalPrice { get; private set; }
    public DateTime OrderDate { get; private set; } = DateTime.Now;
    public BillingDetails? BillingDetails { get; private set; }
    public Payment? Payment { get; private set; }
    public ShippingMethod ShippingMethod { get; private set; }
    public string? OrderNotes { get; set; }
    public OrderStatus OrderStatus { get; private set; }

    private Order()
    {
        
    }

    public Order(Guid id, Guid buyerId, decimal totalPrice, BillingDetails billingDetails, Payment payment, ShippingMethod shippingMethod, string? orderNotes, OrderStatus orderStatus)
    {
        Id = id;
        BuyerId = buyerId;
        TotalPrice = totalPrice;
        BillingDetails = billingDetails;
        Payment = payment;
        ShippingMethod = shippingMethod;
        OrderNotes = orderNotes;
        OrderStatus = orderStatus;
    }
}