namespace IdentityServer.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        public Task<bool> UpdateProfileImage(Guid userId, string profileImageUrl);
    }
}
