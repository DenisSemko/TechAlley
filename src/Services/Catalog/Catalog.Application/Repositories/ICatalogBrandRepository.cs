namespace Catalog.Application.Repositories;

public interface ICatalogBrandRepository : IBaseRepository<CatalogBrand>
{
    Task<CatalogBrand> GetBrandByName (string catalogBrandName);
}