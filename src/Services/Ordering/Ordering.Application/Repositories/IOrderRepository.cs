namespace Ordering.Application.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    new Task<IReadOnlyList<Order>> GetAllAsync(Expression<Func<Order, bool>> predicate);
}