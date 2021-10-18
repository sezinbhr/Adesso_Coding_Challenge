using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.Repository.DataAccess.Concerete;
using Microsoft.Extensions.DependencyInjection;
using AdessoRideShare.Repository.DataAccess.Concrete;

namespace AdessoRideShare.API.Extensions.Startup
{
    public static class DependencyRegister
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<ITripUserRepository, TripUserRepository>();

            return services;
        }
    }
}
