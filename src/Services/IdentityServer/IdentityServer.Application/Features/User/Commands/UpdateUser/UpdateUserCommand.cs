namespace IdentityServer.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{
    public Guid Id { get; set;  }
    public string Name { get; set; }
    public string? MiddleName { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string ProfileImage { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}