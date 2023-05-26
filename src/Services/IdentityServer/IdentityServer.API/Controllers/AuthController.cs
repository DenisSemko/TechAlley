namespace IdentityServer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
   private readonly IAuthService _authService;

   public AuthController(IAuthService authService)
   {
      _authService = authService ?? throw new ArgumentNullException(nameof(authService));;
   }
   
   [HttpPost]
   [Route("registration")]
   public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
   {
      var authResponse = await _authService.RegisterAsync(registerModel);

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
   
   [HttpPost]
   [Route("login")]
   public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
   {
      var authResponse = await _authService.LoginAsync(loginModel);

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
}