namespace Catalog.Domain.Common;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; private init; }
    
    protected BaseEntity(Guid id)
    {
        Id = id;
    }
}