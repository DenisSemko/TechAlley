namespace Basket.Application.Features.Basket.Commands.UpdateBasketItems;

public class UpdateBasketItemsCommandHandler : IRequestHandler<UpdateBasketItemsCommand, Domain.Entities.Basket>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateBasketItemsCommandHandler> _logger;
    
    public UpdateBasketItemsCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateBasketItemsCommandHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Domain.Entities.Basket> Handle(UpdateBasketItemsCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Basket basket = UpdateBasketItemCommandToBasket.Convert(request);
        
        await _unitOfWork.Baskets.UpdateAsync(basket);
        
        _logger.LogInformation(string.Format(Constants.Logs.BasketRefreshed));

        return basket;
    }
}