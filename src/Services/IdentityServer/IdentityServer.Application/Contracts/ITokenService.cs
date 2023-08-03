namespace IdentityServer.Application.Contracts;

public interface ITokenService
{
    Task<string> Generate(ApplicationUser user);
}