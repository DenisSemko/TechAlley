namespace IdentityServer.Application.Contracts;

public interface ITokenService
{
    AuthenticationResult GenerateAuthenticationResult(ApplicationUser user);
    
}