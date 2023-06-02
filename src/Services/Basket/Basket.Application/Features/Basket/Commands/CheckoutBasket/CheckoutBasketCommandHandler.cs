namespace Basket.Application.Features.Basket.Commands.CheckoutBasket;

public class CheckoutBasketCommandHandler : IRequestHandler<CheckoutBasketCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CheckoutBasketCommandHandler> _logger;
    private readonly IMapper _mapper;
    
    public CheckoutBasketCommandHandler(IUnitOfWork unitOfWork, ILogger<CheckoutBasketCommandHandler> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<Unit> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Basket basket = await _unitOfWork.Baskets.GetByIdAsync(request.BuyerId);

        BasketCheckoutEvent checkoutEvent = _mapper.Map<BasketCheckoutEvent>(request);
        //await _publishEndpoint.Publish<BasketCheckoutEvent>(checkoutEvent);
        // _logger.LogInformation(string.Format(Constants.Logs.CatalogItemCreated, catalogItem.Name));
        
        await _unitOfWork.Baskets.DeleteAsync(basket.BuyerId);
        //deleted
        // _logger.LogInformation(string.Format(Constants.Logs.CatalogItemCreated, catalogItem.Name));

        return Unit.Value;
    }
}