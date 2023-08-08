namespace IdentityServer.Application.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
