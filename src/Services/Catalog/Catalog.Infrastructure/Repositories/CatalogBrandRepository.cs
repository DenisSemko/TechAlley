namespace Catalog.Infrastructure.Repositories;

public class CatalogBrandRepository : BaseRepository<CatalogBrand>, ICatalogBrandRepository
{
    public CatalogBrandRepository(IDbSettings settings) : base(settings)
    {
    }
    
    public async Task<CatalogBrand> GetBrandByName(string catalogBrandName) => 
        await GetAsync(catalogBrand => catalogBrand.Brand == catalogBrandName);
}