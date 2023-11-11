namespace Basket.Application.Features.Basket.Queries.GetBasketByBuyerId;

public class GetBasketByBuyerIdQueryHandler : IRequestHandler<GetBasketByBuyerIdQuery, BasketDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetBasketByBuyerIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BasketDto> Handle(GetBasketByBuyerIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.Basket basket = await _unitOfWork.Baskets.GetByIdAsync(request.BuyerId);
        
        if (basket is null)
        {
            throw new KeyNotFoundException(string.Format(Constants.Exceptions.ItemNotFound, nameof(Basket)));
        }
        
        return _mapper.Map<BasketDto>(basket);
    }
}