namespace Basket.Application.Mapper.Converters;

public static class BasketItemsToBasketItemsDto
{
    public static List<BasketItemDto> Convert(Domain.Entities.Basket source)
    {
        return source.Items.Select(basketItem => new BasketItemDto()
        {
            Id = basketItem.Id,
            ProductId = basketItem.ProductId,
            ProductName = basketItem.ProductName,
            Quantity = basketItem.Quantity,
            Color = basketItem.Color,
            Price = basketItem.Price
        }).ToList();
    }
}