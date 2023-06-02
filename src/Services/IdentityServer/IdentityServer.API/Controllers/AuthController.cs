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
   private readonly ILogger<AuthController> _logger;
   
   #endregion
   
   #region ctor
   
   public AuthController(IAuthService authService, ILogger<AuthController> logger)
   {
      _authService = authService ?? throw new ArgumentNullException(nameof(authService));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
      _logger.Log(LogLevel.Information, "Executing Identity Register");
      
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
         Username = authResponse.Username
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
      _logger.Log(LogLevel.Information, "Executing Identity Login");
      
      AuthenticationResult authResponse = await _authService.LoginAsync(loginModel);

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
         Username = authResponse.Username
      });
   }
   #endregion
}