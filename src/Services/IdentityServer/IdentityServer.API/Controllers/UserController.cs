namespace IdentityServer.API.Controllers;

/// <summary>
/// Controller for User operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    #region PrivateFields

    private readonly IMediator _mediator;

    #endregion

    #region ctor

    public UserController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    #endregion

    #region ControllerMethods
    
    /// <summary>
    /// Gets User by ID.
    /// </summary>
    /// <param name="id">
    /// User's ID to get details.
    /// </param>
    /// <returns>
    /// Returns User details by ID.
    /// </returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApplicationUserDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ApplicationUserDto>> GetById(Guid id)
    {
        GetUserByIdQuery query = new () { Id = id };
        
        ApplicationUserDto catalogItem = await _mediator.Send(query);

        return Ok(catalogItem);
    }
    
    /// <summary>
    /// Updates an existing User.
    /// </summary>
    /// <param name="command">
    /// Command for updating an existing User.
    /// </param>
    /// <returns>
    /// Returns No content.
    /// </returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateUserCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    /// <summary>
    /// Deletes User.
    /// </summary>
    /// <param name="id">
    /// User's ID to delete it.
    /// </param>
    /// <returns>
    /// Returns No content.
    /// </returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        DeleteUserCommand command = new () { Id = id };
        
        await _mediator.Send(command);
        return NoContent();
    }
    
    #endregion
}