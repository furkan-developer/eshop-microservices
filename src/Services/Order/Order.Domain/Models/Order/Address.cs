using System.Runtime.ExceptionServices;

namespace Order.Domain;

public record class Address
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string Country { get; } = default!;
    
    protected Address()
    {
    }

    private Address(string firstName, string lastName, string country)
    {
        FirstName = firstName;
        LastName = lastName;
        Country = country;
    }

    public static Address Of(string firstName, string lastName, string country)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(country, nameof(country));

        return new Address(firstName, lastName, country);
    }
}
