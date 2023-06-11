namespace Ordering.Application.Features.Ordering.Commands.AddOrder;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrderDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AddOrderCommandHandler> _logger;
    private readonly IMapper _mapper;

    public AddOrderCommandHandler(IUnitOfWork unitOfWork, ILogger<AddOrderCommandHandler> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<OrderDto> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        OrderDto orderDto = _mapper.Map<OrderDto>(request);
        
        await _unitOfWork.Orders.InsertOneAsync(_mapper.Map<Order>(orderDto));
        
        _logger.LogInformation(string.Format(Constants.Logs.OrderCreated, orderDto.Id));

        return orderDto;
    }
}