namespace IdentityServer.Application.Common;

public class AuthSuccessResponse
{
    public string AccessToken { get; set; }
    public Guid UserId { get; set; }
}