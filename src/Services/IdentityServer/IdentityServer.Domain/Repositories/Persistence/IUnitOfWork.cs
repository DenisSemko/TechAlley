namespace IdentityServer.Domain.Repositories.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
