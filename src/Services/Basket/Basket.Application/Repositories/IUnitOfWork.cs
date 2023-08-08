namespace Basket.Application.Repositories;

public interface IUnitOfWork
{
    IBasketRepository Baskets { get; }
}