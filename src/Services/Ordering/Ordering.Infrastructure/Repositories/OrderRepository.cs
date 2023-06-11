namespace Ordering.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationContext dbContext) : base(dbContext)
    {
    }
    
    public new async Task<IReadOnlyList<Order>> GetAllAsync(Expression<Func<Order, bool>> predicate) =>
        await _dbContext.Set<Order>().Where(predicate).ToListAsync();
}