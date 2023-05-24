namespace IdentityServer.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IJwtOptions _jwtOptions;
    private readonly UserManager<ApplicationUser> _userManager;

    public TokenService(IJwtOptions jwtOptions, UserManager<ApplicationUser> userManager)
    {
        _jwtOptions = jwtOptions ?? throw new ArgumentNullException(nameof(jwtOptions));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }
    
    public AuthenticationResult GenerateAuthenticationResult(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
        var userRoles = _userManager.GetRolesAsync(user).Result;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("id", user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience
        };
        foreach (var userRole in userRoles)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, userRole));
        }

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new AuthenticationResult
        {
            Success = true,
            AccessToken = tokenHandler.WriteToken(token),
            Username = user.UserName
        };
    }
}