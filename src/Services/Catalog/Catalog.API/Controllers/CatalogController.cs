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

    #endregion

    #region ctor

    public CatalogController(IMediator mediator, ILogger<CatalogController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    #endregion

    #region ControllerMethods

    /// <summary>
    /// Gets Catalog Items.
    /// </summary>
    /// <returns>
    /// Returns a PagedList of Catalog Items.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedList<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedList<CatalogItemDto>>> Get([FromQuery] GetCatalogItemsParams catalogItemsParams)
    {
        GetCatalogItemsQuery query = new GetCatalogItemsQuery() { PageNumber = catalogItemsParams.PageNumber, PageSize = catalogItemsParams.PageSize };
        
        PagedList<CatalogItemDto> catalogItems = await _mediator.Send(query);

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
        GetCatalogItemByIdQuery query = new () { Id = id };
        
        CatalogItemDto catalogItem = await _mediator.Send(query);

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
    public async Task<ActionResult<CatalogItemDto>> Post([FromBody] AddCatalogItemCommand command)
    {
        CatalogItemDto result = await _mediator.Send(command);
        
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
    public async Task<ActionResult> Update([FromBody] UpdateCatalogItemCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    //it's an admin feature
    /// <summary>
    /// Deletes Catalog Item.
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
        DeleteCatalogItemCommand command = new () { Id = id };
        
        await _mediator.Send(command);
        return NoContent();
    }
    
    #endregion
}