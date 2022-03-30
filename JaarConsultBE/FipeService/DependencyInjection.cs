using Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FipeService.Context;

namespace FipeService
{
    public static class DependencyInjection
    {
        public static void AddFipeService(this IServiceCollection services,  IConfiguration configuration)
        {
            string _apiPath = configuration.GetSection("ApiBrasil").Value;
            services.AddScoped<IAplicationFipeApi>(s => new AplicationFipeApi("MyConnectionString"));

        }
    }
}
