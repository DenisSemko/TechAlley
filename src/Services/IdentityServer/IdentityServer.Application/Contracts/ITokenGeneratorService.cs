namespace IdentityServer.Application.Contracts;

public interface ITokenGeneratorService
{
    string GenerateToken(Claim[] claims, DateTime expireDate, IList<string>? userRoles = null);
}