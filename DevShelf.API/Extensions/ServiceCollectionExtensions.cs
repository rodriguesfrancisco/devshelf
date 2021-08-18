using DevShelf.Domain.Repositories;
using DevShelf.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevShelf.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
