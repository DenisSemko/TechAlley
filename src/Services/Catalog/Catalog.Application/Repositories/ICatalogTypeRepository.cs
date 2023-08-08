namespace Catalog.Application.Repositories;

public interface ICatalogTypeRepository : IBaseRepository<CatalogType>
{
    Task<CatalogType> GetTypeByName (string catalogTypeName);
}