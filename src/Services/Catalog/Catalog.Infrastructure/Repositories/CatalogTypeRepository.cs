namespace Catalog.Infrastructure.Repositories;

public class CatalogTypeRepository : BaseRepository<CatalogType>, ICatalogTypeRepository
{
    public CatalogTypeRepository(IDbSettings settings) : base(settings)
    {
    }

    public async Task<CatalogType> GetTypeByName(string catalogTypeName) => 
        await GetAsync(catalogType => catalogType.Type == catalogTypeName);
}