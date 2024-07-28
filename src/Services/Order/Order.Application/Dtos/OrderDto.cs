using System.Globalization;
using Order.Domain;

namespace Order.Application;

public record OrderDto(
    Guid CustomerId,
    string OrderName,
    OrderStatus Status,
    AddressDto Address,
    List<OrderItemDto> OrderItems);
