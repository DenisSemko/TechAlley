namespace Ordering.Application.Mapper.Converters;

public class OrdersToOrdersDto : ITypeConverter<IReadOnlyList<Order>, List<OrderDto>>
{
    public List<OrderDto> Convert(IReadOnlyList<Order> source, List<OrderDto> destination,
        ResolutionContext context)
    {
        return source.Select(order => new OrderDto()
        {
            Id = order.Id,
            BuyerId = order.BuyerId,
            TotalPrice = order.TotalPrice,
            OrderDate = order.OrderDate,
            FirstName = order.BillingDetails?.FirstName,
            LastName = order.BillingDetails?.LastName,
            Country = order.BillingDetails?.Country,
            Street = order.BillingDetails?.Street,
            City = order.BillingDetails?.City,
            State = order.BillingDetails?.State,
            PostCode = order.BillingDetails?.PostCode,
            Phone = order.BillingDetails?.Phone,
            EmailAddress = order.BillingDetails?.EmailAddress,
            CardName = order.Payment?.CardName,
            CardNumber = order.Payment?.CardNumber,
            Expiration = order.Payment?.Expiration,
            CVV = order.Payment?.CVV,
            PaymentMethod = order.Payment?.PaymentMethod,
            ShippingMethod = Enum.GetName(typeof(ShippingMethod), order.ShippingMethod),
            OrderNotes = order.OrderNotes,
            OrderStatus = Enum.GetName(typeof(OrderStatus), order.OrderStatus)
        }).ToList();
    }
}