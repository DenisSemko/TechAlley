namespace Catalog.Domain.Common;

public abstract class AggregateRoot : BaseEntity
{
    private List<IDomainEvent> _domainEvents;
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();
    
    protected AggregateRoot(Guid id) : base(id)
    {
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= new List<IDomainEvent>();
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
    
    public IReadOnlyList<IDomainEvent> GetDomainEvents() =>
        _domainEvents.ToList();
}