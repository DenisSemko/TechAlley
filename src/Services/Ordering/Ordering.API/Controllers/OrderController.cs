namespace Ordering.API.Controllers;

/// <summary>
/// Controller for Catalog Items operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    #region PrivateFields

    private readonly IMediator _mediator;

    #endregion

    #region ctor

    public OrderController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    #endregion
    
    #region ControllerMethods
    
    /// <summary>
    /// Gets Orders by Buyer Id.
    /// </summary>
    /// <param name="buyerId">
    /// Order's ID to get details.
    /// </param>
    /// <returns>
    /// Returns a List of Orders.
    /// </returns>
    [HttpGet("{buyerId}")]
    [ProducesResponseType(typeof(IEnumerable<OrderDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetByBuyerId(Guid buyerId)
    {
        GetOrdersByBuyerIdQuery query = new GetOrdersByBuyerIdQuery() { BuyerId = buyerId };
        
        List<OrderDto> catalogItems = await _mediator.Send(query);

        return Ok(catalogItems);
    }
    
    /// <summary>
    /// Creates a new Order.
    /// </summary>
    /// <param name="command">
    /// Command for adding a new Order.
    /// </param>
    /// <returns>
    /// Returns newly created Order.
    /// </returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult<OrderDto>> Post([FromBody] AddOrderCommand command)
    {
        OrderDto result = await _mediator.Send(command);
        
        return CreatedAtAction(nameof(Post), result);
    }
    
    /// <summary>
    /// Updates an existing Order.
    /// </summary>
    /// <param name="command">
    /// Command for updating an existing Order.
    /// </param>
    /// <returns>
    /// Returns No content.
    /// </returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    /// <summary>
    /// Delete Order.
    /// </summary>
    /// <param name="id">
    /// Order's ID to delete it.
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
        DeleteOrderCommand command = new DeleteOrderCommand() { Id = id };
        
        await _mediator.Send(command);
        return NoContent();
    }
    
    #endregion
}