namespace IdentityServer.Infrastructure.Repository;

public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
{
    public UserRepository(ApplicationContext applicationContext) : base(applicationContext)
    {
    }

    public async Task<bool> UpdateProfileImage(Guid userId, string profileImageUrl)
    {
        var user = await GetByIdAsync(userId);

        if (user != null)
        {
            user.ProfileImage = profileImageUrl;
            await _applicationContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}