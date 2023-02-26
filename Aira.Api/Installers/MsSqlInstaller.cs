using Aira.Persistence.Aira;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aira.Api.Installers
{
    public static class MsSqlInstaller
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
#if DEBUG
            services.AddDbContext<AiraContext>(options => options.UseSqlite(configuration.GetConnectionString("MsSql.Aira")));
#else
            services.AddDbContext<AiraContext>(options => options.UseSqlServer(configuration.GetConnectionString("MsSql.Aira")));
#endif
        }
    }
}