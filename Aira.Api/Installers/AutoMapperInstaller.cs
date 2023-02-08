using System;
using Microsoft.Extensions.DependencyInjection;

namespace Aira.Api.Installers
{
    public static class AutoMapperInstaller
    {
        public static void AddAutoMapperWithProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
