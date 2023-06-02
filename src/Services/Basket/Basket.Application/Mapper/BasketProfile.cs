namespace Basket.Application.Mapper;

public class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<Domain.Entities.Basket, BasketDto>()
            .ConvertUsing(new BasketToBasketDto());
        CreateMap<CheckoutBasketCommand, BasketCheckoutEvent>().ReverseMap();
    }
}