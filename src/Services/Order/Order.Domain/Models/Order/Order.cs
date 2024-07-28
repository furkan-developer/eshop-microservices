using System.Diagnostics;
using System.Security.AccessControl;

namespace Order.Domain;

public sealed class Order : Entity, IAggregateRoot
{
    private readonly List<OrderItem> _orderItems = new();
    private Order(Guid id, Guid customerId, Address shippingAddress) : base(id)
    {
        CustomerId = customerId;
        ShippingAddress = shippingAddress;
    }

    public Guid CustomerId { get; private set; }
    public Address ShippingAddress { get; private set; }
    public OrderStatus OrderStatus { get; private set; } = OrderStatus.Pending;
    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        private set { }
    }

    public IReadOnlyList<OrderItem> OrderItems => _orderItems;

    public static Order Create(Guid id, Guid customerId, Address shippingAddress)
    {
        var order = new Order(id,customerId,shippingAddress); 
        
        order.AddDomainEvent(new OrderCreatedDomainEvent(order));

        return order;
    }

    public void AddOrderItem(Guid id, Guid productId, int quantity, decimal price){
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        if(quantity <=0) throw new DomainException(DomainExceptionMessages.ORDER_QUANTITY_NEGATIFE_OR_ZERO);
        if(price <=0) throw new DomainException(DomainExceptionMessages.ORDER_PRICE_NEGATIFE_OR_ZERO);

        var orderItem = new OrderItem(id, Id, productId, quantity, price);
        _orderItems.Add(orderItem);
    }

    public void Update(Address shippingAddress, OrderStatus orderStatus){
        ShippingAddress = shippingAddress;
        OrderStatus = orderStatus;

        AddDomainEvent(new OrderUpdatedDomainEvent(this));
    }

    public void RemoveOrderItem(Guid productId){
        var orderItem = _orderItems.SingleOrDefault(x => x.ProductId == productId);
        if(orderItem is null){
            throw new Exception();    
        }
        
        _orderItems.Remove(orderItem);
    }
}
