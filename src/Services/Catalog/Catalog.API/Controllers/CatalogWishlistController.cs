namespace Catalog.API.Controllers;

/// <summary>
/// Controller for Catalog Wishlists operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CatalogWishlistController : ControllerBase
{
    #region PrivateFields
    
    private readonly IMediator _mediator;
    
    #endregion
    
    #region ctor
    
    public CatalogWishlistController(IMediator mediator, ILogger<CatalogWishlistController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    #endregion

    #region Controller Methods

    /// <summary>
    /// Gets Catalog Wishlist by Buyer ID.
    /// </summary>
    /// <param name="buyerId">
    /// Catalog Wishlist Buyer's ID to get details.
    /// </param>
    /// <returns>
    /// Returns Catalog Wishlist details.
    /// </returns>
    [HttpGet("{buyerId:guid}")]
    [ProducesResponseType(typeof(CatalogWishlistDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CatalogWishlistDto>> GetByBuyerId(Guid buyerId)
    {
        GetCatalogWishlistByBuyerIdQuery query = new () { BuyerId = buyerId };
        
        CatalogWishlistDto catalogWishlist = await _mediator.Send(query);

        return Ok(catalogWishlist);
    }
    
    /// <summary>
    /// Gets Catalog Item From the Wishlist.
    /// </summary>
    /// <param name="buyerId">
    /// Catalog Wishlist Buyer's ID to get details.
    /// </param>
    /// <param name="catalogItemId">
    /// Catalog Item's ID.
    /// </param>
    /// <returns>
    /// Returns bool.
    /// </returns>
    [HttpGet("{buyerId:guid}/{catalogItemId:guid}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> GetCatalogItemFromWishlist(Guid buyerId, Guid catalogItemId)
    {
        GetCatalogItemFromWishlistQuery query = new () { BuyerId = buyerId, CatalogItemId = catalogItemId};
        
        bool isCatalogItemFound = await _mediator.Send(query);

        return Ok(isCatalogItemFound);
    }
    
    /// <summary>
    /// Creates a new Catalog Wishlist.
    /// </summary>
    /// <param name="command">
    /// Command for adding a new Catalog Wishlist.
    /// </param>
    /// <returns>
    /// Returns newly created Catalog Wishlist.
    /// </returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult<CatalogWishlistDto>> Post([FromBody] AddCatalogWishlistCommand command)
    {
        CatalogWishlistDto result = await _mediator.Send(command);
        
        return CreatedAtAction(nameof(Post), result);
    }
    
    /// <summary>
    /// Updates an existing Catalog Wishlist.
    /// </summary>
    /// <param name="command">
    /// Command for updating an existing Catalog Wishlist.
    /// </param>
    /// <returns>
    /// Returns No content.
    /// </returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateCatalogWishlistCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    /// <summary>
    /// Deletes Catalog Item from the Wishlist.
    /// </summary>
    /// <param name="buyerId">
    /// Catalog Wishlist Buyer's ID to find the wishlist.
    /// </param>
    /// <param name="catalogItemId">
    /// Catalog Item's ID to delete it from the wishlist.
    /// </param>
    /// <returns>
    /// Returns No content.
    /// </returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteCatalogItemFromWishlist(Guid buyerId, Guid catalogItemId)
    {
        DeleteCatalogItemFromWishlistCommand command = new () { BuyerId = buyerId, CatalogItemId = catalogItemId};
        
        await _mediator.Send(command);
        return NoContent();
    }
    
    #endregion
}