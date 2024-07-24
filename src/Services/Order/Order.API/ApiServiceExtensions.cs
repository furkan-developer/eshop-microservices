namespace Order.API;

public static class ApiServiceExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration){

        return services;
    }

    public static WebApplication HandleRequestPipeline(this WebApplication app){

        app.MapGet("/", () => "Hello World!");

        return app;
    } 
}
