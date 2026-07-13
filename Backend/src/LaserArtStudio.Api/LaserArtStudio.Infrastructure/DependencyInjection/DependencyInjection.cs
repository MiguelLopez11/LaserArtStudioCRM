using LaserArtStudio.Application.Common.Interfaces;
using LaserArtStudio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaserArtStudio.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    });
            });
            services.AddScoped<IApplicationDbContext>(
    provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
