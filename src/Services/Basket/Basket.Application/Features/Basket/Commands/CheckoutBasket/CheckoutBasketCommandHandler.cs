namespace Basket.Application.Features.Basket.Commands.CheckoutBasket;

public class CheckoutBasketCommandHandler : IRequestHandler<CheckoutBasketCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public CheckoutBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
    }
    
    public async Task<Unit> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Basket basket = await _unitOfWork.Baskets.GetByIdAsync(request.BuyerId);
        
        if (basket is null)
        {
            throw new KeyNotFoundException(string.Format(Constants.Exceptions.ItemNotFound, nameof(Basket)));
        }
        
        BasketCheckoutEvent checkoutEvent = _mapper.Map<BasketCheckoutEvent>(request);
        
        await _publishEndpoint.Publish<BasketCheckoutEvent>(checkoutEvent, cancellationToken);

        return Unit.Value;
    }
}