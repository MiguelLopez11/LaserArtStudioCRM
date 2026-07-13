using MediatR;
using LaserArtStudio.Domain.Entities;
using LaserArtStudio.Application.Common.Interfaces;

namespace LaserArtStudio.Application.Features.Customers.Commands.CreateCustomer;

public sealed class CreateCustomerCommandHandler
    : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = new Customer(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber);

        _context.Customers.Add(customer);

        await _context.SaveChangesAsync(cancellationToken);

        return customer.CustomerId;
    }
}