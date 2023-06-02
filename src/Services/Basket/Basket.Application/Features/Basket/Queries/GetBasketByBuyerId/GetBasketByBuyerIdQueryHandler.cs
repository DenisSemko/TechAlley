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
        var basket = await _unitOfWork.Baskets.GetByIdAsync(request.BuyerId);
        return _mapper.Map<BasketDto>(basket);
    }
}