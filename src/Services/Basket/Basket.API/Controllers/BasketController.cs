namespace Basket.API.Controllers;

/// <summary>
/// Controller for Basket operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BasketController : Controller
{
    #region PrivateFields
    
    private readonly IMediator _mediator;
    
    #endregion
    
    #region ctor
    
    public BasketController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    #endregion
    
    #region ControllerMethods
    
    /// <summary>
    /// Gets Basket.
    /// </summary>
    /// <param name="id">
    /// Buyer's ID to get basket.
    /// </param>
    /// <returns>
    /// Returns a Basket with Items.
    /// </returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BasketDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BasketDto>> GetById(Guid id)
    {
        GetBasketByBuyerIdQuery query = new GetBasketByBuyerIdQuery() { BuyerId = id };
        
        BasketDto basket = await _mediator.Send(query);

        return Ok(basket ?? new BasketDto() { Id = Guid.NewGuid(), BuyerId = id, Items = new()});
    }
    
    /// <summary>
    /// Creates a new Basket with Items or refreshes the existing one.
    /// </summary>
    /// <param name="command">
    /// Command for adding/refresh a Basket.
    /// </param>
    /// <returns>
    /// Returns created/refreshed Basket.
    /// </returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Domain.Entities.Basket>> Post([FromBody] UpdateBasketItemsCommand command)
    {
        Domain.Entities.Basket result = await _mediator.Send(command);
        
        return Ok(result);
    }
    
    /// <summary>
    /// Creates a checkout for the Basket with Items.
    /// </summary>
    /// <param name="command">
    /// Command to checkout a Basket.
    /// </param>
    /// <returns>
    /// Returns Accepted.
    /// </returns>
    [HttpPost("checkout")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Checkout([FromBody] CheckoutBasketCommand command)
    {
        Unit result = await _mediator.Send(command);
        
        return Accepted();
    }
    
    /// <summary>
    /// Delete Basket.
    /// </summary>
    /// <param name="id">
    /// Buyer's ID to delete basket.
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
        DeleteBasketCommand command = new () { BuyerId = id };
        await _mediator.Send(command);
        
        return NoContent();
    }
    
    #endregion
}