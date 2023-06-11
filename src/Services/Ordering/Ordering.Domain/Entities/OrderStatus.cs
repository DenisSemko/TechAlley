namespace Ordering.Domain.Entities;

public enum OrderStatus
{
    Submitted,
    AwaitingValidation,
    Confirmed,
    Paid,
    Shipped,
    Cancelled
}