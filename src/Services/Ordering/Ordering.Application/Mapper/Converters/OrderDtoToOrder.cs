namespace Ordering.Application.Mapper.Converters;

public class OrderDtoToOrder : ITypeConverter<OrderDto, Order>
{
    public Order Convert(OrderDto source, Order destination, ResolutionContext context)
    {
        return new Order(
            source.Id, source.BuyerId, source.TotalPrice, new BillingDetails(source.FirstName, source.LastName,
            source.Country, source.Street, source.City, source.State, source.PostCode, source.Phone, source.EmailAddress), 
            new Payment(source.CardName, source.CardNumber, source.Expiration, source.CVV, source.PaymentMethod), 
            (ShippingMethod) Enum.Parse(typeof(ShippingMethod), source.ShippingMethod), source.OrderNotes,
            (OrderStatus) Enum.Parse(typeof(OrderStatus), source.OrderStatus));
    }
}