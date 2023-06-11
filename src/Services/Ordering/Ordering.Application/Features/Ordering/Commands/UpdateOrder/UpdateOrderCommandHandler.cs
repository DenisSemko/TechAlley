namespace Ordering.Application.Features.Ordering.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateOrderCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateOrderCommandHandler> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        Order updatedItem = _mapper.Map<Order>(request);

        await _unitOfWork.Orders.UpdateAsync(updatedItem);
        
        _logger.LogInformation(Constants.Logs.OrderUpdated, updatedItem.Id);

        return Unit.Value;
    }
}