namespace Order.Application;

public record OrderItemDto(Guid ProductId, int Quantity, decimal Price);
