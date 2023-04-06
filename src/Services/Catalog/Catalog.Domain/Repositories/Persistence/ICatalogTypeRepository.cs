namespace Catalog.Domain.Repositories.Persistence;

public interface ICatalogTypeRepository : IBaseRepository<CatalogType>
{
    Task<CatalogType> GetTypeByName (string catalogTypeName);
}