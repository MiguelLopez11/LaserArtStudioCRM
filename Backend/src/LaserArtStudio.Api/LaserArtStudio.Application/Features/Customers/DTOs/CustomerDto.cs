using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserArtStudio.Application.Features.Customers.DTOs
{

    public sealed record CustomerDto
    (
        int Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        bool IsActive
    );
}
