namespace Catalog.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    #region Private fields
    private readonly IDbSettings _mongoSettings;
    #endregion

    #region ctor
    public UnitOfWork(IDbSettings settings)
    {
        _mongoSettings = settings;
    }
    #endregion

    #region Repositories
    
    private IBaseRepository<CatalogItem> catalogItemRepository;
    public IBaseRepository<CatalogItem> CatalogItems => catalogItemRepository ?? new BaseRepository<CatalogItem>(_mongoSettings);
    
    private IBaseRepository<CatalogType> catalogTypeRepository;
    public IBaseRepository<CatalogType> CatalogTypes => catalogTypeRepository ?? new BaseRepository<CatalogType>(_mongoSettings);
    
    private IBaseRepository<CatalogBrand> catalogBrandRepository;
    public IBaseRepository<CatalogBrand> CatalogBrands => catalogBrandRepository ?? new BaseRepository<CatalogBrand>(_mongoSettings);
    
    #endregion
}