namespace Basket.Application.Mapper.Converters;

public static class UpdateBasketItemCommandToBasket
{
    public static Domain.Entities.Basket Convert(UpdateBasketItemsCommand source)
    {
        return new Domain.Entities.Basket(
            source.Id,
            source.BuyerId)
        {
            Items = source.Items
        };
    }
}