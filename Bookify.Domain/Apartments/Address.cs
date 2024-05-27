namespace Bookify.Domain.Apartments;

public record Address(
    string Country,
    string State,
    string Zip,
    string City,
    string Street
);