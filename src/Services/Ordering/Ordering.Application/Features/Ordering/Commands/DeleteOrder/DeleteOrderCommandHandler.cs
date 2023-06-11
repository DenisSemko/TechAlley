namespace Ordering.Application.Features.Ordering.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteOrderCommandHandler> _logger;

    public DeleteOrderCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteOrderCommandHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = await _unitOfWork.Orders.GetAsync(order => order.BuyerId == request.Id);
        if (order is null)
        {                
            throw new KeyNotFoundException(nameof(Order));
        }

        await _unitOfWork.Orders.DeleteAsync(order);
        _logger.LogInformation(Constants.Logs.OrderDeleted);
    }
}