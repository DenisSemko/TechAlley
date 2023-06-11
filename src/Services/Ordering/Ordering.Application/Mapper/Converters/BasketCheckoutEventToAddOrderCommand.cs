namespace Ordering.Application.Mapper.Converters;

public class BasketCheckoutEventToAddOrderCommand : ITypeConverter<BasketCheckoutEvent, AddOrderCommand>
{
    public AddOrderCommand Convert(BasketCheckoutEvent source, AddOrderCommand destination, ResolutionContext context)
    {
        return new AddOrderCommand()
        {
            BuyerId = source.BuyerId,
            TotalPrice = source.TotalPrice,
            ShippingMethod = source.ShippingMethod,
            OrderStatus = source.OrderStatus
        };
    }
}