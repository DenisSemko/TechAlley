namespace IdentityServer.Application.Contracts;

public interface IAuthenticationResultService
{
    Task<AuthenticationResult> GenerateAuthenticationResult(ApplicationUser user);
}