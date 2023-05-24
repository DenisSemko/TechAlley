namespace IdentityServer.Application.Mapper.Converters;

public class RegisterModelToApplicationUser : ITypeConverter<RegisterModel, ApplicationUser>
{
    public ApplicationUser Convert(RegisterModel source, ApplicationUser destination, ResolutionContext context)
    {
        return new ApplicationUser()
        {
            Name = source.Name,
            Surname = source.Surname,
            BirthDate = source.BirthDate,
            UserName = source.Username,
            Email = source.Email,
            PasswordHash = source.PasswordHash,
            RegistrationDate = DateTime.Now
        };
    }
}