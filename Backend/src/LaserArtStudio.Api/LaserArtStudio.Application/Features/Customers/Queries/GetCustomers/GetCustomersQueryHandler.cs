using LaserArtStudio.Application.Common.Interfaces;
using LaserArtStudio.Application.Features.Customers.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserArtStudio.Application.Features.Customers.Queries.GetCustomers
{
    public sealed class GetCustomersQueryHandler
    : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetCustomersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerDto>> Handle(
            GetCustomersQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Customers
                .AsNoTracking()
                .Select(customer => new CustomerDto(
                    customer.Id,
                    customer.FirstName,
                    customer.LastName,
                    customer.Email,
                    customer.PhoneNumber,
                    customer.IsActive))
                .ToListAsync(cancellationToken);
        }
    }
}
