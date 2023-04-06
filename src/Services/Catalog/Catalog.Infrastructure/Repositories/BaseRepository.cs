namespace Catalog.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly IMongoCollection<T> _collection;

    public BaseRepository(IDbSettings settings)
    {
        var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
    }
    
    private protected string? GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                typeof(BsonCollectionAttribute),
                true)
            .FirstOrDefault()!)?.CollectionName;
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync() => 
        await _collection.Find(_ => true).ToListAsync();

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate) =>
        await _collection.Find(predicate).SingleOrDefaultAsync();

    public async Task<T> GetByIdAsync(Guid id)
    {
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
        return await _collection.Find(filter).SingleOrDefaultAsync();
    }
    
    public async Task<bool> AnyAsync()
    {
        var count = await _collection.CountDocumentsAsync(FilterDefinition<T>.Empty);
        return count > 0;
    }

    public async Task InsertOneAsync(T entity) => 
        await _collection.InsertOneAsync(entity);

    public async Task UpdateAsync(T entity)
    {
        var filter = Builders<T>.Filter.Eq(doc => doc.Id, entity.Id);
        await _collection.FindOneAndReplaceAsync(filter, entity);
    }

    public async Task DeleteAsync(Expression<Func<T, bool>> predicate) =>
        await _collection.FindOneAndDeleteAsync(predicate);
}