namespace Basket.Domain.Repositories.Persistence;

public interface IBasketRepository : IBaseRepository<Entities.Basket>
{
     public new Task<Domain.Entities.Basket> UpdateAsync(Domain.Entities.Basket entity);
}