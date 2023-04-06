namespace Catalog.Domain.Repositories.Persistence;

public interface IBaseRepository<T> where T : BaseEntity
{
    #region Methods
    
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(Guid id);
    Task<bool> AnyAsync();
    Task InsertOneAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Expression<Func<T, bool>> predicate);
    
    #endregion
}