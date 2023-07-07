using CQRS.API.Application.Commands.Handlers;
using CQRS.API.Application.Commands.Handlers.Interfaces;
using CQRS.API.Core.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.API.Application.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationCommandService(this IServiceCollection services)
        {
            services.AddCommandHandlers();

            return services;
        }

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            //services.Scan(s =>
            //    s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            //        .AddClasses(c => c.AssignableTo(typeof(IHandlerBase<>))
            //            .WithoutAttribute(typeof(DecoratorAttribute)))
            //        .AsImplementedInterfaces()
            //        .WithTransientLifetime());

            services.AddTransient<CreateUserHandler>();

            return services;
        }
    }
}
