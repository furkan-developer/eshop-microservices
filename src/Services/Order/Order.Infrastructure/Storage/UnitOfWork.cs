using Microsoft.EntityFrameworkCore;
using Order.Application;

namespace Order.Infrastructure;

public class UnitOfWork(ApplicationDbContext applicationDbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await applicationDbContext.SaveChangesAsync();
    }
}
