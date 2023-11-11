namespace IdentityServer.API.Controllers;

/// <summary>
/// Controller for Identity operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
   #region PrivateFields
   
   private readonly IAuthService _authService;
   private readonly UserManager<ApplicationUser> _userManager;
   private readonly IAuthenticationResultService _authenticationResultService;
   
   #endregion
   
   #region ctor
   
   public AuthController(IAuthService authService, UserManager<ApplicationUser> userManager, IAuthenticationResultService authenticationResultService)
   {
      _authService = authService ?? throw new ArgumentNullException(nameof(authService));
      _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
      _authenticationResultService = authenticationResultService ?? throw new ArgumentNullException(nameof(authenticationResultService));
   }
   
   #endregion

   #region ControllerMethods
   
   /// <summary>
   /// Registers a new User.
   /// </summary>
   /// <param name="registerModel">
   /// Register Model.
   /// </param>
   /// <returns>
   /// Returns a new User.
   /// </returns>
   [HttpPost]
   [Route("registration")]
   [ProducesResponseType(typeof(RegisterModel), (int)HttpStatusCode.Created)]
   public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
   {
      AuthenticationResult authResponse = await _authService.RegisterAsync(registerModel);
      if (!authResponse.Success)
      {
         return BadRequest(new AuthFailedResponse
         {
            Errors = authResponse.Errors
         });
      }

      return Ok(new AuthSuccessResponse
      {
         AccessToken = authResponse.AccessToken,
         RefreshToken = authResponse.RefreshToken,
         UserId = authResponse.UserId
      });
   }
   
   /// <summary>
   /// Logins user to the system.
   /// </summary>
   /// <param name="loginModel">
   /// Login Model.
   /// </param>
   /// <returns>
   /// Returns login's model.
   /// </returns>
   [HttpPost]
   [Route("login")]
   [ProducesResponseType(typeof(LoginModel), (int)HttpStatusCode.OK)]
   public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
   {
      AuthenticationResult authResponse = await _authService.LoginAsync(loginModel);
      if (!authResponse.Success)
      {
         return BadRequest(new AuthFailedResponse
         {
            Errors = authResponse.Errors
         });
      }
      
      Response.Cookies.Append("Authorization", authResponse.AccessToken, new CookieOptions
      {
         HttpOnly = true
      });
      
      Response.Cookies.Append("Refresh", authResponse.RefreshToken, new CookieOptions
      {
         HttpOnly = true
      });

      return Ok(new AuthSuccessResponse
      {
         AccessToken = authResponse.AccessToken,
         RefreshToken = authResponse.RefreshToken,
         UserId = authResponse.UserId
      });
   }
   
   /// <summary>
   /// Refreshes user's tokens.
   /// </summary>
   /// <param name="accessToken">
   /// User's access token.
   /// </param>
   /// <returns>
   /// Returns AuthSuccessResponse model.
   /// </returns>
   [HttpGet("{accessToken}")]
   [ProducesResponseType(typeof(AuthSuccessResponse), (int)HttpStatusCode.OK)]
   public async Task<ActionResult<AuthSuccessResponse>> RefreshTokens(string accessToken)
   {
      JwtSecurityTokenHandler tokenHandler = new ();
      JwtSecurityToken accessTokenInfo = tokenHandler.ReadJwtToken(accessToken);
      Claim? userNameClaim = accessTokenInfo.Claims.FirstOrDefault(claim => claim.Type == "name");
      ApplicationUser existingUser = await _userManager.FindByNameAsync(userNameClaim.Value);
      AuthenticationResult response = await _authenticationResultService.GenerateAuthenticationResult(existingUser);
      
      return Ok(new AuthSuccessResponse
      {
         AccessToken = response.AccessToken,
         RefreshToken = response.RefreshToken,
      });
   }
   #endregion
}