namespace IdentityServer.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IJwtOptions _jwtOptions;

    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, ITokenService tokenService, IMapper mapper, IJwtOptions jwtOptions)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _jwtOptions = jwtOptions ?? throw new ArgumentNullException(nameof(jwtOptions));
    }
    
    public async Task<AuthenticationResult> RegisterAsync(RegisterModel registerModel)
    {
        ApplicationUser existingUser = await _userManager.FindByNameAsync(registerModel.Username);

        if (existingUser is not null)
        {
            return new AuthenticationResult
            {
                Errors = new[] { Constants.Errors.UsernameAlreadyExists }
            };
        }
        
        ApplicationUser newUser = _mapper.Map<ApplicationUser>(registerModel);
        newUser.ProfileImage = "";
        //Work with Profile Image
        //newUser.ProfileImage = _profileImageService..

        var createdUser = await _userManager.CreateAsync(newUser, registerModel.PasswordHash);

        if (!createdUser.Succeeded)
        {
            return new AuthenticationResult
            {
                Errors = createdUser.Errors.Select(x => x.Description)
            };
        }

        if (!await _roleManager.RoleExistsAsync(Constants.Roles.User))
            await _roleManager.CreateAsync(new IdentityRole<Guid>(Constants.Roles.User));
        if (await _roleManager.RoleExistsAsync(Constants.Roles.User))
        {
            await _userManager.AddToRoleAsync(newUser, Constants.Roles.User);
        }

        return _tokenService.GenerateAuthenticationResult(newUser);
    }
    
    public async Task<AuthenticationResult> LoginAsync(LoginModel loginModel)
    {

        ApplicationUser user = await _userManager.FindByNameAsync(loginModel.Username);

        if (user is null)
        {
            return new AuthenticationResult
            {
                Errors = new[] { Constants.Errors.UserDoesNotExist }
            };
        }
        bool userHasValidPassword = await _userManager.CheckPasswordAsync(user, loginModel.Password);

        if (!userHasValidPassword)
        {
            return new AuthenticationResult
            {
                Errors = new[] { Constants.Errors.WrongCredentials }
            };
        }

        return _tokenService.GenerateAuthenticationResult(user);
    }
}