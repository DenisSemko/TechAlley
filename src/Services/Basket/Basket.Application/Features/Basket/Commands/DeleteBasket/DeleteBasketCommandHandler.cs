namespace Basket.Application.Features.Basket.Commands.DeleteBasket;

public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteBasketCommandHandler> _logger;

    public DeleteBasketCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteBasketCommandHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Basket basket = await _unitOfWork.Baskets.GetByIdAsync(request.BuyerId);
        if (basket is null)
        {                
            throw new KeyNotFoundException(nameof(Basket));
        }

        await _unitOfWork.Baskets.DeleteAsync(request.BuyerId);
        _logger.LogInformation(Constants.Logs.BasketDeleted, basket.Id);
    }
}