namespace Basket.Application.Features.Basket.Commands.DeleteBasket;

public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBasketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Basket basket = await _unitOfWork.Baskets.GetByIdAsync(request.BuyerId);
        
        if (basket is null)
        {                
            throw new KeyNotFoundException(string.Format(Constants.Exceptions.ItemNotFound, nameof(Basket)));
        }

        await _unitOfWork.Baskets.DeleteAsync(request.BuyerId);
    }
}