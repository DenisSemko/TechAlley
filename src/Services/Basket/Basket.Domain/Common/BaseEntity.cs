namespace Basket.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; private init; }
    
    protected BaseEntity(Guid id)
    {
        Id = id;
    }
}