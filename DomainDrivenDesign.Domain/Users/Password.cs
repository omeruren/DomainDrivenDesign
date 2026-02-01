namespace DomainDrivenDesign.Domain.Users;
#region ValueObjects

public sealed record Password
{
    public string Value { get; init; }

    public Password(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Password can not be empty.");
        if (value.Length <= 3)
            throw new ArgumentException("Password can not be less than 3 characters.");

        Value = value;
    }
}

#endregion