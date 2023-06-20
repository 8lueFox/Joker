using Joker.Framework.Types;

namespace Joker.Framework.Entities;

public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

    public IEnumerable<IDomainEvent> Events => _events;
    public AggregateId Id { get; protected set; } = new();
    public int Version { get; protected set; }

    protected void AddEvent(IDomainEvent domainEvent)
        => _events.Add(domainEvent);

    public void ClearEvents() => _events.Clear();
}
