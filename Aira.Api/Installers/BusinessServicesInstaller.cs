using Aira.Application.Creator.Repositories;
using Aira.Application.Creator.Uow;
using Aira.Application.Creator.Uow.Interface;

namespace Aira.Api.Installers
{
    public static class BusinessServicesInstaller
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IJobOfferAdditionalInfoRepository, JobOfferAdditionalInfoRepository>();
            services.AddScoped<IJobOfferContentEducationRepository, JobOfferContentEducationRepository>();
            services.AddScoped<IJobOfferContentRepository, JobOfferContentRepository>();
            services.AddScoped<IJobOfferMainRepository, JobOfferMainRepository>();
            services.AddScoped<IJobOfferRepository, JobOfferRepository>();

            services.AddScoped<IJobOfferUnitOfWork, JobOfferUnitOfWork>();
        }
    }
}
