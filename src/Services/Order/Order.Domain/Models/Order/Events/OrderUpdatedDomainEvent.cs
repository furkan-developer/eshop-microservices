namespace Order.Domain;


public record OrderUpdatedDomainEvent(Order order) : IDomainEvent;
