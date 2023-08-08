namespace Basket.Application.Repositories;

public interface IBasketRepository : IBaseRepository<Domain.Entities.Basket>
{
     public new Task<Domain.Entities.Basket> UpdateAsync(Domain.Entities.Basket entity);
}