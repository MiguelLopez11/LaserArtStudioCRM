using LaserArtStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace LaserArtStudio.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
