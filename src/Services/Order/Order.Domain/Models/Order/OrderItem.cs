namespace Order.Domain;

public class OrderItem : Entity
{
    internal OrderItem(Guid orderItemId, Guid orderId, Guid productId, int quantity, decimal price) : base(orderItemId)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    private OrderItem(){}

    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
}
