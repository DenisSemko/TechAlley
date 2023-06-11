namespace Ordering.Domain.Repositories;

public interface IUnitOfWork
{
    IOrderRepository Orders { get; }
}