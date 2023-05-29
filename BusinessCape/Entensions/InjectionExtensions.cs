using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessCape.Entensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var assembly = typeof(SENAONPRINTINGContext).Assembly.FullName;
            var conn = configuration.GetConnectionString("AppConnection");
            services.AddDbContext<SENAONPRINTINGContext>(
                options => options.UseSqlServer(
                    conn, b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
            return services;
        }
    }
}
