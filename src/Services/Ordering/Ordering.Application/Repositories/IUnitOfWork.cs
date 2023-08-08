namespace Ordering.Application.Repositories;

public interface IUnitOfWork
{
    IOrderRepository Orders { get; }
}