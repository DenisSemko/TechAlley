namespace Basket.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    #region Private fields
    private readonly IDistributedCache _distributedCache;
    #endregion

    #region ctor
    public UnitOfWork(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }
    #endregion

    #region Repositories
    
    private IBasketRepository basketRepository;
    public IBasketRepository Baskets => basketRepository ?? new BasketRepository(_distributedCache);
    
    #endregion
}