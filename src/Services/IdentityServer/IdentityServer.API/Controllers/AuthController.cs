namespace IdentityServer.API.Controllers;

[ApiController]
[Route("[controller]")]
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
}