namespace Catalog.Application.Mapper.Converters;

public static class UpdateCatalogWishlistCommandToCatalogWishlist
{
    public static CatalogWishlist Convert(UpdateCatalogWishlistCommand source, List<CatalogItem> catalogItems)
    {
        return new CatalogWishlist(source.Id, catalogItems, source.BuyerId);
    }
}