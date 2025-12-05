using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JornadaEscala.Infrastructure.Persistence
{
    /// <summary>
    /// Extensões para IServiceCollection que registram o DbContext
    /// e aplicam migrations automaticamente no startup da API.
    /// </summary>
    public static class PersistenceServiceExtensions
    {
        /// <summary>
        /// Registra o JornadaDbContext no container de DI e aplica migrations.
        /// </summary>
        /// <param name="services">Coleção de serviços da aplicação.</param>
        /// <param name="configuration">Configurações da aplicação (appsettings.json).</param>
        /// <returns>Retorna IServiceCollection para encadeamento.</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o DbContext com a connection string do appsettings.json
            services.AddDbContext<JornadaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Aplica migrations automaticamente ao iniciar a aplicação
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<JornadaDbContext>();
                db.Database.Migrate();
            }

            return services;
        }
    }
}
