using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Order.Application;

namespace Order.API;

public static class ApiServiceExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }

    public static WebApplication HandleRequestPipeline(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");

        app.MapPost("/", async ([FromServices] ISender sender) =>
        {
            var result = await sender.Send(new CreateOrderCommand(new OrderDto(Guid.NewGuid(), Guid.NewGuid(), "OrderName", Domain.OrderStatus.Pending, new AddressDto("name", "surname", "country"), new List<OrderItemDto>() { new OrderItemDto(Guid.NewGuid(), 10, 100) })));

            return Results.Ok(new { id = result.Id });
        });

        return app;
    }
}
