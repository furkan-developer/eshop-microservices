using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BuildingBlocks.CQRS;
using Carter;
using Catalog.Products.Domain;
using Mapster;
using Marten;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Products.Features;
public record CreateProductResult(Guid Id);
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;

internal class CreateProductCommandHandler(IDocumentSession documentSession) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Adapt<Product>();

        documentSession.Store(product);
        documentSession.SaveChangesAsync();

        var result = product.Adapt<CreateProductResult>();
    
        return Task.Run(()=> result);
    }
}
public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/catalog/products",
            async ([FromBody]CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>();

            return Results.Created($"/api/catalog/products/{result.Id}",response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
