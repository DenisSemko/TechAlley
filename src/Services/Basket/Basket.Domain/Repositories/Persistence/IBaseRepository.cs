namespace Basket.Domain.Repositories.Persistence;

public interface IBaseRepository<T> where T : BaseEntity
{
    #region Methods
    
    Task<T> GetByIdAsync(Guid id);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    
    #endregion
}