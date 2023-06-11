namespace Ordering.Application.Features.Ordering.Commands.AddOrder;

public class AddOrderCommand : IRequest<OrderDto>
{
    public Guid BuyerId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Country { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostCode { get; set; }
    public string? Phone { get; set; }
    public string? EmailAddress { get; set; }
    public string? CardName { get; set; }
    public string? CardNumber { get; set; }
    public string? Expiration { get; set; }
    public string? CVV { get; set; }
    public int? PaymentMethod { get; set; }
    public string ShippingMethod { get; set; }
    public string? OrderNotes { get; set; }
    public string OrderStatus { get; set; }
}