using IdentityService.Domain.Events;

namespace IdentityService.Domain.Common;

/// <summary>
/// Aggregate kökü için temel sınıf. Domain event'leri toplar ve dışarıya sunar.
/// Sadece aggregate kökü üzerinden aggregate dışına erişim yapılmalıdır.
/// </summary>
public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected AggregateRoot() { }

    protected AggregateRoot(int id) : base(id) { }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
