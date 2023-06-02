namespace Basket.Domain.Repositories.Persistence;

public interface IUnitOfWork
{
    IBasketRepository Baskets { get; }
}