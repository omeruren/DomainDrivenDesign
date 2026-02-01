namespace DomainDrivenDesign.Domain.Users;
#region ValueObjects

public sealed record Address(
string Country,
string City,
string Street,
string PostalCode);

#endregion