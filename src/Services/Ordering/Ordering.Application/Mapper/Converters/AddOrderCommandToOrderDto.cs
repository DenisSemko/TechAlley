namespace Ordering.Application.Mapper.Converters;

public class AddOrderCommandToOrderDto : ITypeConverter<AddOrderCommand, OrderDto>
{
    public OrderDto Convert(AddOrderCommand source, OrderDto destination, ResolutionContext context)
    {
        ShippingMethod shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), source.ShippingMethod);
        return new OrderDto()
        {
            Id = Guid.NewGuid(),
            BuyerId = source.BuyerId,
            TotalPrice = shippingMethod == ShippingMethod.Standard ? source.TotalPrice + 10 : (shippingMethod == ShippingMethod.Express ? source.TotalPrice + 20 : source.TotalPrice),
            OrderDate = source.OrderDate,
            FirstName = source.FirstName,
            LastName = source.LastName,
            City = source.City,
            Country = source.Country,
            Street = source.Street,
            EmailAddress = source.EmailAddress,
            Phone = source.Phone,
            State = source.State,
            PostCode = source.PostCode,
            CardName = source.CardName,
            CardNumber = source.CardNumber,
            Expiration = source.Expiration,
            CVV = source.CVV,
            PaymentMethod = source.PaymentMethod,
            ShippingMethod = source.ShippingMethod,
            OrderNotes = source.OrderNotes,
            OrderStatus = source.OrderStatus
        };
    }
}