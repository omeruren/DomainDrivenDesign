namespace DomainDrivenDesign.Domain.Abstractions;
public abstract class BaseEntity : IEquatable<BaseEntity>
{

    public Guid Id { get; init; }

    protected BaseEntity(Guid id)
    {
        Id = id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj is not BaseEntity entity) return false;

        if (obj.GetType() != GetType()) return false;

        return entity.Id == Id;
    }

    public bool Equals(BaseEntity? other)
    {
        if (other is null) return false;

        if (other is not BaseEntity entity) return false;

        if (other.GetType() != GetType()) return false;

        return entity.Id == Id;
    }
}
