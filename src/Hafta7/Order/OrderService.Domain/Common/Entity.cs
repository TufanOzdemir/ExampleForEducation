namespace OrderService.Domain.Common;

/// <summary>
/// Tüm domain entity'leri için temel sınıf.
/// Kimlik ve eşitlik karşılaştırması Id üzerinden yapılır.
/// </summary>
public abstract class Entity
{
    public int Id { get; protected set; }

    protected Entity() { }

    protected Entity(int id)
    {
        Id = id;
    }

    public override bool Equals(object? obj) => obj is Entity other && Id == other.Id && GetType() == other.GetType();

    public override int GetHashCode() => HashCode.Combine(GetType(), Id);

    public static bool operator ==(Entity? left, Entity? right)
    {
        if (left is null && right is null)
            return true;
        if (left is null || right is null)
            return false;
        return left.Equals(right);
    }

    public static bool operator !=(Entity? left, Entity? right) => !(left == right);
}
