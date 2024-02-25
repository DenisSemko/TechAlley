namespace Catalog.Domain.Entities.Events;

public sealed record CatalogItemCreatedEvent(Guid CatalogItemId) : IDomainEvent;