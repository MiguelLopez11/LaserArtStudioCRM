using LaserArtStudio.Application.Features.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserArtStudio.Application.Features.Customers.Queries.GetCustomers
{
    public sealed record GetCustomersQuery()
    : IRequest<List<CustomerDto>>;
}
