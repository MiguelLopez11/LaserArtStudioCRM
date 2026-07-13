using LaserArtStudio.Application.Features.Customers.Commands.CreateCustomer;
using LaserArtStudio.Application.Features.Customers.Queries.GetCustomers;
using MediatR;
namespace LaserArtStudio.Api.Endpoints;

public static class CustomerEndpoints
{
    public static IEndpointRouteBuilder MapCustomerEndpoints(
        this IEndpointRouteBuilder app)
    {
        app.MapPost("/customers", CreateCustomer);
        app.MapGet("/customers", GetCustomers);

        return app;
    }

    private static async Task<IResult> CreateCustomer(
        CreateCustomerCommand command,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var customerId = await mediator.Send(command, cancellationToken);

        return Results.Created(
            $"/customers/{customerId}",
            customerId);
    }
    private static async Task<IResult> GetCustomers(
    IMediator mediator,
    CancellationToken cancellationToken)
    {
        var customers = await mediator.Send(
            new GetCustomersQuery(),
            cancellationToken);

        return Results.Ok(customers);
    }
}