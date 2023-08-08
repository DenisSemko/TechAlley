namespace Catalog.Application.Repositories;

public interface IUnitOfWork
{
    ICatalogItemRepository CatalogItems { get; }
    ICatalogTypeRepository CatalogTypes { get; }
    ICatalogBrandRepository CatalogBrands { get; }
    ICatalogWishlistRepository CatalogWishlists { get; }
}