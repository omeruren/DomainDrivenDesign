namespace DomainDrivenDesign.Domain.Users;
#region ValueObjects


public sealed record Email
{
    public string Value { get; init; }

    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Email can not be empty.");
        if (value.Length <= 3)
            throw new ArgumentException("Email can not be less than 3 characters.");
        if (!value.Contains('@'))
            throw new ArgumentException("Please enter valid mail.");
        Value = value;
    }
}

#endregion