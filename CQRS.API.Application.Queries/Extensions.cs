using CQRS.API.Application.Queries.Handlers;
using CQRS.API.Application.Queries.Interfaces;
using CQRS.API.Core.Types;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace CQRS.API.Application.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationQueryService(this IServiceCollection services)
        {
            services.AddQueryHandlers();

            return services;
        }        

        private static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<GetUserByIdHandler>();

            //services.Scan(s =>
            //    s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            //        .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>))
            //            .WithoutAttribute(typeof(DecoratorAttribute)))
            //        .AsImplementedInterfaces()
            //        .WithTransientLifetime());

            return services;
        }
    }
}
