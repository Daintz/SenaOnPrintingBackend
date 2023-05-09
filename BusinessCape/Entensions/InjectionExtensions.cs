using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersistenceCape.Contexts;

namespace BusinessCape.Entensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var assembly = typeof(SENAContext).Assembly.FullName;
            var conn = configuration.GetConnectionString("AppConnection");
            services.AddDbContext<SENAContext>(
                options => options.UseSqlServer(
                    conn, b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
            return services;
        }
    }
}
