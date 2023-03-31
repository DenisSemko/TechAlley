namespace Catalog.Domain.Repositories.Persistence;

public interface IUnitOfWork
{
    IBaseRepository<CatalogItem> CatalogItems { get; }
    IBaseRepository<CatalogType> CatalogTypes { get; }
    IBaseRepository<CatalogBrand> CatalogBrands { get; }
}