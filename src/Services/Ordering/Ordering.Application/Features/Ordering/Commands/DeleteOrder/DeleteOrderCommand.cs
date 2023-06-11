namespace Ordering.Application.Features.Ordering.Commands.DeleteOrder;

public class DeleteOrderCommand : IRequest
{
    public Guid Id { get; set; }
}