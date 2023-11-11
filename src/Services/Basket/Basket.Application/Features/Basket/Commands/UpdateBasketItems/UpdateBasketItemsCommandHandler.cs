namespace Basket.Application.Features.Basket.Commands.UpdateBasketItems;

public class UpdateBasketItemsCommandHandler : IRequestHandler<UpdateBasketItemsCommand, Domain.Entities.Basket>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateBasketItemsCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Domain.Entities.Basket> Handle(UpdateBasketItemsCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Basket basket = UpdateBasketItemCommandToBasket.Convert(request);
        
        await _unitOfWork.Baskets.UpdateAsync(basket);
        
        return basket;
    }
}