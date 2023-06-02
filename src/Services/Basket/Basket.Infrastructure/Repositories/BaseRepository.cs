namespace Basket.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    public IDistributedCache _redisCache;

    public BaseRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        string item = await _redisCache.GetStringAsync(id.ToString());
            
        if (String.IsNullOrEmpty(item))
            return null;

        return JsonConvert.DeserializeObject<T>(item);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await _redisCache.SetStringAsync(entity.Id.ToString(), JsonConvert.SerializeObject(entity));

        return await GetByIdAsync(entity.Id);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _redisCache.RemoveAsync(id.ToString());
    }
}