using Ecommerce.Applicattion.CQRS.Queries.Users.TakenLogin;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ecommerce.Applicattion.Dependencies
{
    public static class ApplicationDependency
    {
        public static void AddApplicationHandlers(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentException(nameof(services));
            services.AddMediatR(typeof(TakeLoginQuery));
        }
    }
}
