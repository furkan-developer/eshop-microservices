namespace Order.Application;

public interface IOrderRepository
{
    void Create(Domain.Order order);
}
