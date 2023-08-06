namespace IdentityServer.Application.Mapper;

public class ApplicationUserProfile : Profile
{
    public ApplicationUserProfile()
    {
        CreateMap<RegisterModel, ApplicationUser>()
            .ConvertUsing(new RegisterModelToApplicationUser());
        CreateMap<ApplicationUser, ApplicationUserDto>()
            .ConvertUsing(new ApplicationUserToApplicationUserDto());
        CreateMap<UpdateUserCommand, ApplicationUser>()
            .ConvertUsing(new UpdateUserCommandToApplicationUser());
    }
}