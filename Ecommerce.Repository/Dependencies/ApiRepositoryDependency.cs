using Ecommerce.ApiRepository.Repositories;
using Ecommerce.Core.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ecommerce.ApiRepository.Dependencies
{
    public static class ApiRepositoryDependency
    {
        public static void AddApiRepository(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentException(nameof(services));

        
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}

