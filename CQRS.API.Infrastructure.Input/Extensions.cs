using CQRS.API.Core.Repositories;
using CQRS.API.Infrastructure.Input.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.API.Infrastructure.Input
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureInput(this IServiceCollection services)
        {
            services
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWriteUserRepository, WriteUserRepository>();

            return services;
        }
    }
}
