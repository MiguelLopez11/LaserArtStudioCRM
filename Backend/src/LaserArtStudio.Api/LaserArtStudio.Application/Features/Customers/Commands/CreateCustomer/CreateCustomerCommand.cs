using MediatR;

namespace LaserArtStudio.Application.Features.Customers.Commands.CreateCustomer;

public sealed record CreateCustomerCommand(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
) : IRequest<int>;