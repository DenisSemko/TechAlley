namespace Ordering.Application.Features.Ordering.Queries.GetOrdersByBuyerId;

public class GetOrdersByBuyerIdQueryHandler : IRequestHandler<GetOrdersByBuyerIdQuery, List<OrderDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetOrdersByBuyerIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<OrderDto>> Handle(GetOrdersByBuyerIdQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Order> orders = await _unitOfWork.Orders.GetAllAsync(o => o.BuyerId == request.BuyerId);
        return _mapper.Map<List<OrderDto>>(orders);
    }
}