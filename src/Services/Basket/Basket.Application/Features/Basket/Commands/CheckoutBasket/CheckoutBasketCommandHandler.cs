namespace Basket.Application.Features.Basket.Commands.CheckoutBasket;

public class CheckoutBasketCommandHandler : IRequestHandler<CheckoutBasketCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CheckoutBasketCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public CheckoutBasketCommandHandler(IUnitOfWork unitOfWork, ILogger<CheckoutBasketCommandHandler> logger, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
    }
    
    public async Task<Unit> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Basket basket = await _unitOfWork.Baskets.GetByIdAsync(request.BuyerId);
        BasketCheckoutEvent checkoutEvent = _mapper.Map<BasketCheckoutEvent>(request);
        
        await _publishEndpoint.Publish<BasketCheckoutEvent>(checkoutEvent, cancellationToken);
        _logger.LogInformation(string.Format(Constants.Logs.BasketCheckoutEvent));

        return Unit.Value;
    }
}