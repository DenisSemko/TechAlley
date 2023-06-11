namespace Ordering.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    #region Private fields
    private readonly ApplicationContext _applicationContext;
    #endregion

    #region ctor
    public UnitOfWork(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    #endregion

    #region Repositories
    
    private IOrderRepository orderRepository;
    public IOrderRepository Orders => orderRepository ?? new OrderRepository(_applicationContext);
    
    #endregion
}