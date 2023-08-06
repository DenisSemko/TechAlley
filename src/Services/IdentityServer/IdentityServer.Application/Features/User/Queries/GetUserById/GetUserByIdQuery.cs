namespace IdentityServer.Application.Features.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<ApplicationUserDto>
{
    public Guid Id { get; set; }
}