namespace Ordering.Application.Features.Ordering.Commands.AddOrder;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrderDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<OrderDto> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        OrderDto orderDto = _mapper.Map<OrderDto>(request);
        
        await _unitOfWork.Orders.InsertOneAsync(_mapper.Map<Order>(orderDto));
        
        return orderDto;
    }
}