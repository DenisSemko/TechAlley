namespace Ordering.Domain.Entities;
public class BillingDetails : ValueObject
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Country { get; private set; }
    public string? Street { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? PostCode { get; private set; }
    public string? Phone { get; private set; }
    public string? EmailAddress { get; private set; }

    private BillingDetails()
    {

    }

    public BillingDetails(string? firstName, string? lastName, string? country, string? street, string? city, string? state, string? postCode, string? phone, string? emailAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        Country = country;
        Street = street;
        City = city;
        State = state;
        PostCode = postCode;
        Phone = phone;
        EmailAddress = emailAddress;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return Country;
        yield return Street;
        yield return City;
        yield return State;
        yield return PostCode;
        yield return Phone;
        yield return EmailAddress;
    }
}