namespace IdentityServer.Application.Mapper.Converters;

public class UpdateUserCommandToApplicationUser : ITypeConverter<UpdateUserCommand, ApplicationUser>
{
    public ApplicationUser Convert(UpdateUserCommand source, ApplicationUser destination, ResolutionContext context)
    {
        destination.Id = source.Id;
        destination.Name = source.Name;
        destination.MiddleName = source.MiddleName;
        destination.Surname = source.Surname;
        destination.BirthDate = source.BirthDate;
        destination.ProfileImage = source.ProfileImage;
        destination.UserName = source.Username;
        destination.Email = source.Email;
        destination.PhoneNumber = source.PhoneNumber;
        return destination;
    }
}