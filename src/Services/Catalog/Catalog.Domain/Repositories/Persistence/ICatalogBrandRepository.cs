namespace Catalog.Domain.Repositories.Persistence;

public interface ICatalogBrandRepository : IBaseRepository<CatalogBrand>
{
    Task<CatalogBrand> GetBrandByName (string catalogBrandName);
}