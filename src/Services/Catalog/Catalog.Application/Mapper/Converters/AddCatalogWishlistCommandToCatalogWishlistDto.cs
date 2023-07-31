namespace Catalog.Application.Mapper.Converters;

public class AddCatalogWishlistCommandToCatalogWishlistDto : ITypeConverter<AddCatalogWishlistCommand, CatalogWishlistDto>
{
    public CatalogWishlistDto Convert(AddCatalogWishlistCommand source, CatalogWishlistDto destination, ResolutionContext context)
    {
        return new CatalogWishlistDto()
        {
            Id = Guid.NewGuid(), 
            BuyerId = source.BuyerId,
            CatalogItems = source.CatalogItems
        };
    }
}