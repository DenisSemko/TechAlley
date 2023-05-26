namespace IdentityServer.Application.Contracts;

public interface IAuthService
{
    Task<AuthenticationResult> RegisterAsync(RegisterModel user);
    Task<AuthenticationResult> LoginAsync(LoginModel user);
}