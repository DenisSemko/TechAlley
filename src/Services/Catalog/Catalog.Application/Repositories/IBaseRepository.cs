namespace Catalog.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    #region Methods
    
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(Guid id);
    Task<bool> AnyAsync();
    Task InsertOneAsync(T entity);
    Task InsertManyAsync(List<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Expression<Func<T, bool>> predicate);
    
    #endregion
}