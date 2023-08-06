namespace IdentityServer.Application.Mapper.Converters;

public class ApplicationUserToApplicationUserDto : ITypeConverter<ApplicationUser, ApplicationUserDto>
{
    public ApplicationUserDto Convert(ApplicationUser source, ApplicationUserDto destination, ResolutionContext context)
    {
        return new ApplicationUserDto()
        {
            Id = source.Id,
            BirthDate = source.BirthDate,
            Email = source.Email,
            MiddleName = source.MiddleName,
            Name = source.Name,
            PhoneNumber = source.PhoneNumber,
            ProfileImage = source.ProfileImage,
            RegistrationDate = source.RegistrationDate,
            Surname = source.Surname,
            Username = source.UserName
        };
    }
}