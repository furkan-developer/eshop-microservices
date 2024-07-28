using System.Net;
using System.Security.Authentication.ExtendedProtection;

namespace Order.Domain;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(Guid id)
    {
        Id = id;
        CreatedAt = DateTime.Now;
        LastModified = DateTime.Now;
    }
    
    protected Entity()
    {
        
    }

    public Guid Id { get; private init; }
    public DateTime CreatedAt { get; private set; }
    public DateTime LastModified { get; private set; }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDoaminEvent()
    {
        _domainEvents.Clear();
    }
}
