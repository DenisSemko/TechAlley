namespace Ordering.Application.Features.Ordering.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = await _unitOfWork.Orders.GetAsync(order => order.BuyerId == request.Id);
        if (order is null)
        {                
            throw new KeyNotFoundException(nameof(Order));
        }

        await _unitOfWork.Orders.DeleteAsync(order);
    }
}