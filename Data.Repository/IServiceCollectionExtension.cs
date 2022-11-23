using Data.Repository.Implementations;
using Data.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repository {
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddMyRepositories(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext, AppDbContext>();
            services.AddScoped<IInstrumentsRepository, InstrumentsRepository>();

            return services;
        }
    }
}
