namespace DomainDrivenDesign.Domain.Shared;
public sealed record Name
{
    public string Value { get; init; }

    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Name can not be empty.");
        if (value.Length <= 3)
            throw new ArgumentException("Name can not be less than 3 characters.");

        Value = value;
    }
}