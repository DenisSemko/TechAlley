namespace Catalog.Infrastructure.Repositories;

public class CatalogWishlistRepository : BaseRepository<CatalogWishlist>, ICatalogWishlistRepository
{
    public CatalogWishlistRepository(IDbSettings settings) : base(settings)
    {
    }
}