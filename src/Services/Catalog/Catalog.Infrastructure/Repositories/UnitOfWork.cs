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
    
    private ICatalogItemRepository catalogItemRepository;
    public ICatalogItemRepository CatalogItems => catalogItemRepository ?? new CatalogItemRepository(_mongoSettings);
    
    private ICatalogTypeRepository catalogTypeRepository;
    public ICatalogTypeRepository CatalogTypes => catalogTypeRepository ?? new CatalogTypeRepository(_mongoSettings);
    
    private ICatalogBrandRepository catalogBrandRepository;
    public ICatalogBrandRepository CatalogBrands => catalogBrandRepository ?? new CatalogBrandRepository(_mongoSettings);
    
    #endregion
}