using CQRS.API.Core.Repositories;
using CQRS.API.Infrastructure.Output.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.API.Infrastructure.Output
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureOutput(this IServiceCollection services)
        {
            services
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IReadUserRepository, ReadUserRepository>();

            return services;
        }
    }
}
