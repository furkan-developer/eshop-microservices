using System.Runtime.ExceptionServices;

namespace Order.Domain;

public record class Address
{
    public string FirstName { get; init;} = default!;
    public string LastName { get; init;} = default!;
    public string Country { get; init;} = default!;
    
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
