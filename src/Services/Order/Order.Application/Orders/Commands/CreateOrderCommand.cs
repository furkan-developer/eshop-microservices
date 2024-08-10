using System.Net.Cache;
using BuildingBlocks.CQRS;
using Order.Domain;

namespace Order.Application;

public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);
public class CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var address = Address.Of(request.Order.Address.FirstName, request.Order.Address.LastName, request.Order.Address.Country);

        var order = Domain.Order.Create(Guid.NewGuid(), request.Order.CustomerId, address);
        request.Order.OrderItems.ForEach(x => order.AddOrderItem(Guid.NewGuid(), x.ProductId, x.Quantity, x.Price));

        orderRepository.Create(order);
        await unitOfWork.SaveChangesAsync();

        return new CreateOrderResult(order.Id);
    }
}