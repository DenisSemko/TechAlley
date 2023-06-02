namespace Basket.Infrastructure.Repositories;

public class BasketRepository : BaseRepository<Domain.Entities.Basket>, IBasketRepository
{
    public BasketRepository(IDistributedCache distributedCache) : base(distributedCache)
    {
        
    }
    
    public new async Task<Domain.Entities.Basket> UpdateAsync(Domain.Entities.Basket entity)
    {
        await _redisCache.SetStringAsync(entity.BuyerId.ToString(), JsonConvert.SerializeObject(entity));

        return await GetByIdAsync(entity.BuyerId);
    }
}