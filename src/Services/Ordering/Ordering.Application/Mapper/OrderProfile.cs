using EventBus.Messages.Events;

namespace Ordering.Application.Mapper;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<IReadOnlyList<Order>, List<OrderDto>>()
            .ConvertUsing(new OrdersToOrdersDto());
        CreateMap<AddOrderCommand, OrderDto>()
            .ConvertUsing(new AddOrderCommandToOrderDto());
        CreateMap<OrderDto, Order>()
            .ConvertUsing(new OrderDtoToOrder());
        CreateMap<UpdateOrderCommand, Order>()
            .ConvertUsing(new UpdateOrderCommandToOrder());
        CreateMap<BasketCheckoutEvent, AddOrderCommand>()
            .ConvertUsing(new BasketCheckoutEventToAddOrderCommand());
    }
}