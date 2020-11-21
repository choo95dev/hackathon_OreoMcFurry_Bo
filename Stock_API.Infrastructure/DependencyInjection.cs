using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock_API.Application.Interfaces;
using Stock_API.Infrastructure.Repository;
using Stock_API.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_API.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddHttpClient<IStockService, StockService>();
            services.AddScoped<MongoDBContext>();
            services.AddTransient<IPlayerScoreRepository, PlayerScoreRepository>();
            return services;
        }
    }
}
