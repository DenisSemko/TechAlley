namespace IdentityServer.Application.Common;

public class AuthFailedResponse
{
    public IEnumerable<string> Errors { get; set; }
}