namespace Catalog.Domain.Repositories.Persistence;

public interface IBaseRepository<T> where T : BaseEntity
{
    #region Methods
    
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Expression<Func<T, bool>> predicate);
    
    #endregion
}