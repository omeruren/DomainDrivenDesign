namespace DomainDrivenDesign.Domain.Shared;
public sealed record Currency
{
    internal static readonly Currency Default = new("TRY");
    private static readonly Currency TRY = new("TRY");
    private static readonly Currency Usd = new("usd");

    public string Code { get; init; }

    private Currency(string code)
    {
        Code = code;
    }

    public static Currency CheckCurrencyType(string code)
    {
        return All.FirstOrDefault(p => p.Code == code)
            ?? throw new ArgumentException("Please enter valid Currency type");
    }
    public static readonly IReadOnlyCollection<Currency> All = new[] { TRY, Usd };
}

public sealed record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new ArgumentException("Different types of currency cannot be combined.");
        return new(a.Amount + b.Amount, a.Currency);
    }

    public static Money Zero() => new(0, Currency.Default);
    public static Money Zero(Currency currency) => new(0, currency);
    public bool IsZero() => this == Zero(Currency);

}
