using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Users;
public sealed class User : BaseEntity
{
    private User(Guid Id, Name name, Email email, Password password, Address address)
    : base(Id)
    {
        Name = name;
        Email = email;
        Password = password;
        Address = address;
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Address Address { get; private set; }


    public static User CreateUser(string name, string email, string password, string country, string city, string street, string postalCode)
    {
        User user = new(
            Id: Guid.CreateVersion7(),
            name: new(name),
            email: new(email),
            password: new(password),
            address: new(country, city, street, postalCode));

        return user;
    }

    public void ChangeNameValue(string value) => Name = new(value);
    public void ChangeEmailValue(string value) => Email = new(value);
    public void ChangeAddressValue(string country, string city, string street, string postalCode)
        => Address = new(country, city, street, postalCode);
    public void ChangePasswordValue(string value) => Password = new(value);

}
