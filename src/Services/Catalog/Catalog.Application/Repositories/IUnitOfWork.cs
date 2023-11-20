namespace Catalog.Application.Repositories;

public interface IUnitOfWork
{
    IBaseRepository<CatalogItem> CatalogItems { get; }
    ICatalogTypeRepository CatalogTypes { get; }
    ICatalogBrandRepository CatalogBrands { get; }
    IBaseRepository<CatalogWishlist> CatalogWishlists { get; }
}