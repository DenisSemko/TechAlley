namespace IdentityServer.Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationContext _applicationContext;

    public BaseRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() =>
        await _applicationContext.Set<T>().ToListAsync();

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate) =>
        await _applicationContext.Set<T>().FindAsync(predicate);

    public async Task<T> GetByIdAsync(Guid id) =>
        await _applicationContext.Set<T>().FindAsync(id);

    public async Task<bool> AnyAsync()
    {
        var count = await _applicationContext.Set<T>().CountAsync();
        return count > 0;
    }

    public async Task InsertOneAsync(T entity)
    {
        await _applicationContext.Set<T>().AddAsync(entity);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _applicationContext.Set<T>().Update(entity);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        T entity = await _applicationContext.Set<T>().FindAsync(id);
        _applicationContext.Set<T>().Remove(entity);
        await _applicationContext.SaveChangesAsync();
    }
}