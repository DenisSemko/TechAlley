namespace IdentityServer.Application.Mapper;

public class ApplicationUserProfile : Profile
{
    public ApplicationUserProfile()
    {
        CreateMap<RegisterModel, ApplicationUser>()
            .ConvertUsing(new RegisterModelToApplicationUser());
    }
}