using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application;
using Order.Infrastructure.Storage.Repositories;

namespace Order.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration){


        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("SQLServer")));

        services.AddScoped<IOrderRepository,OrderRepository>();
        services.AddScoped<IUnitOfWork,UnitOfWork>();

        return services;
    }
}
