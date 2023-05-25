namespace Catalog.API.Controllers;

/// <summary>
/// Controller for Catalog Items operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    #region PrivateFields

    private readonly IMediator _mediator;
    private readonly ILogger<CatalogController> _logger;

    #endregion

    #region ctor

    public CatalogController(IMediator mediator, ILogger<CatalogController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    #endregion

    #region ControllerMethods

    /// <summary>
    /// Gets Catalog Items.
    /// </summary>
    /// <returns>
    /// Returns a List of Catalog Items.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CatalogItemDto>>> Get()
    {
        var query = new GetCatalogItemsQuery();
        
        _logger.Log(LogLevel.Information, "Executing CatalogItem Get");
        var catalogItems = await _mediator.Send(query);

        return Ok(catalogItems);
    }
    
    /// <summary>
    /// Gets Catalog Item by ID.
    /// </summary>
    /// <param name="id">
    /// Catalog Item's ID to get details.
    /// </param>
    /// <returns>
    /// Returns Catalog Item details by ID.
    /// </returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CatalogItemDto>> GetById(Guid id)
    {
        var query = new GetCatalogItemByIdQuery() { Id = id };
        
        _logger.Log(LogLevel.Information, "Executing CatalogItem GetById");
        var catalogItem = await _mediator.Send(query);

        return Ok(catalogItem);
    }
    
    //it's an admin feature
    /// <summary>
    /// Creates a new Catalog Item.
    /// </summary>
    /// <param name="command">
    /// Command for adding a new Catalog Item.
    /// </param>
    /// <returns>
    /// Returns newly created Catalog Item.
    /// </returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult<CatalogItem>> Post([FromBody] AddCatalogItemCommand command)
    {
        _logger.Log(LogLevel.Information, "Executing CatalogItem Post");
        var result = await _mediator.Send(command);
        
        return CreatedAtAction(nameof(Post), result);
    }
    
    //it's an admin feature
    /// <summary>
    /// Updates an existing Catalog Item.
    /// </summary>
    /// <param name="command">
    /// Command for updating an existing Catalog Item.
    /// </param>
    /// <returns>
    /// Returns No content.
    /// </returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateOrder([FromBody] UpdateCatalogItemCommand command)
    {
        _logger.Log(LogLevel.Information, "Executing CatalogItem Put");
        await _mediator.Send(command);
        return NoContent();
    }
    
    //it's an admin feature
    /// <summary>
    /// Delete Catalog Item.
    /// </summary>
    /// <param name="id">
    /// Catalog Item's ID to delete it.
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
        var command = new DeleteCatalogItemCommand() { Id = id };
        
        _logger.Log(LogLevel.Information, "Executing CatalogItem Delete");
        
        await _mediator.Send(command);
        return NoContent();
    }
    
    #endregion

}