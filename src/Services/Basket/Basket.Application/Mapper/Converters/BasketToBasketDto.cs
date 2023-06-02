namespace Basket.Application.Mapper.Converters;

public class BasketToBasketDto : ITypeConverter<Domain.Entities.Basket, BasketDto>
{
    public BasketDto Convert(Domain.Entities.Basket source, BasketDto destination, ResolutionContext context)
    {
        return new BasketDto()
        {
            Id = source.Id,
            Items = BasketItemsToBasketItemsDto.Convert(source),
            BuyerId = source.BuyerId,
            TotalPrice = source.TotalPrice,
            TotalItems = source.TotalItems
        };
    }
}