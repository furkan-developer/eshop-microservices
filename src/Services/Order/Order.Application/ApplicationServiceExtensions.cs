using Microsoft.Extensions.DependencyInjection;

namespace Order.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services){

        return services;
    }
}
