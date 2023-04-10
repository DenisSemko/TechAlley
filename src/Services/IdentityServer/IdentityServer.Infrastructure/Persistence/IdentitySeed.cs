namespace IdentityServer.Infrastructure.Persistence;

public class IdentitySeed
{
    public static async Task SeedData(ApplicationContext applicationContext, ILogger<IdentitySeed> logger)
    {
        if (!applicationContext.ApplicationUsers.Any())
        {
            await applicationContext.ApplicationUsers.AddAsync(new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                Name = "Test User",
                MiddleName = "Middle name",
                Surname = "Test Userovenko",
                Email = "venomven93o@gmail.com",
                UserName = "test",
                PasswordHash = "$2y$04$m1nApz5nSGBuITpvK4QWseZNmDbze53yY2sMjzuc3kLbJwTR8dvcm",
                BirthDate = new DateTime(1999, 12, 01),
                ProfileImage = "src/image",
                RegistrationDate = DateTime.Now
            });
            await applicationContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationContext).Name);
        }
    }
}