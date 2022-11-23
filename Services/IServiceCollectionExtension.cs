using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Interfaces;

namespace Services {
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IInstrumentsService, InstrumentsService>();

            return services;
        }
    }
}
