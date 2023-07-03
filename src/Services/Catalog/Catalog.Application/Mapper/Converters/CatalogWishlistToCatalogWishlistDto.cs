namespace Catalog.Application.Mapper.Converters;

public class CatalogWishlistToCatalogWishlistDto : ITypeConverter<CatalogWishlist, CatalogWishlistDto>
{
    public CatalogWishlistDto Convert(CatalogWishlist source, CatalogWishlistDto destination, ResolutionContext context)
    {
        return new CatalogWishlistDto()
        {
            Id = source.Id,
            BuyerId = source.BuyerId,
            CatalogItems = StaticCatalogItemsToCatalogItemsDto.Convert(source.CatalogItems)
        };
    }
}