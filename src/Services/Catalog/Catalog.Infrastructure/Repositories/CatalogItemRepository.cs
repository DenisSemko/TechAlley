namespace Catalog.Infrastructure.Repositories;

public class CatalogItemRepository : BaseRepository<CatalogItem>, ICatalogItemRepository
{
    public CatalogItemRepository(IDbSettings settings) : base(settings)
    {
    }
}