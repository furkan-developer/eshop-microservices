namespace Order.Domain;

public record OrderCreatedDomainEvent(Order order) : IDomainEvent;