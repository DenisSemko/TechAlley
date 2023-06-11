namespace Ordering.Domain.Entities;
public class Payment : ValueObject
{
    public string? CardName { get; private set; }
    public string? CardNumber { get; private set; }
    public string? Expiration { get; private set; }
    public string? CVV { get; private set; }
    public int? PaymentMethod { get; private set; }

    private Payment()
    {
    }

    public Payment(string? cardName, string? cardNumber, string? expiration, string? cvv, int? paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CardName;
        yield return CardNumber;
        yield return Expiration;
        yield return CVV;
        yield return PaymentMethod;
    }
}