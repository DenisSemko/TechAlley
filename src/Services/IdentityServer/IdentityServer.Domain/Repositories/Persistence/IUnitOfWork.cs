namespace IdentityServer.Domain.Repositories.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
