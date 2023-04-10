namespace IdentityServer.Infrastructure.Repository;

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
    
    private IUserRepository userRepository;
    public IUserRepository ApplicationUsers => userRepository ?? new UserRepository(_applicationContext);
    
    #endregion

    public IUserRepository UserRepository { get; }
    
    public async Task<bool> Complete() => 
        await _applicationContext.SaveChangesAsync() > 0;

    public bool HasChanges()
    {
        _applicationContext.ChangeTracker.DetectChanges();
        bool changes = _applicationContext.ChangeTracker.HasChanges();

        return changes;
    }
}