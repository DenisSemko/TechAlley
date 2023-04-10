namespace IdentityServer.Domain.Repositories.Persistence;

public interface IUserRepository : IBaseRepository<ApplicationUser>
{
    public Task<bool> UpdateProfileImage(Guid userId, string profileImageUrl);
}