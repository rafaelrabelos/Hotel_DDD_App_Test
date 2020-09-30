using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using hotel.domain.interfaces;
using hotel.application.services;
using hotel.application.services.interfaces;
using hotel.infra.data;
using hotel.infra.data.Configuration;
namespace hotel.infra.ioc
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // ASPNET
            services.AddSingleton(configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Connections
            services.AddScoped<IDbConnection>(ctx => DapperConnectionFactory.Connection(configuration.GetConnectionString("DefaultConnection")));

            // Services
            services.AddScoped<IHotelService, HotelService>();

            // Infra - Data
            services.AddScoped<IHotelRepository, HotelRepository>();
        }
    }
}
