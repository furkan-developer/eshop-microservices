using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Carter;
using Catalog.Products.Domain;
using Mapster;
using Marten;
using MediatR;

namespace Catalog.Products.Features
{
    public record GetProductsQuery(): IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    
    internal class GetProductsQueryHandler(IDocumentSession documentSession) : IRequestHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await documentSession.Query<Product>().ToListAsync();
            
            return new GetProductsResult(products);
        }
    }

    public record GetProductsRequest();
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/catalog/products",async (ISender sender)=>{
                
                var result = await sender.Send(new GetProductsQuery());
                
                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
        }
    }
}