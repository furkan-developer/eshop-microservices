using System;
using Order.Application;

namespace Order.Infrastructure.Storage.Repositories;

public class OrderRepository(ApplicationDbContext applicationDbContext) : IOrderRepository
{
    public void Create(Domain.Order order) => applicationDbContext.Set<Domain.Order>().Add(order);
}
