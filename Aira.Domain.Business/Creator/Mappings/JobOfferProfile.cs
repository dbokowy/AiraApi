using Aira.Domain.Business.Creator.Command;
using Aira.Domain.Business.Creator.Dto;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aira.Domain.Business.Creator.Mappings
{
    public class JobOfferProfile : Profile
    {
        public JobOfferProfile()
        {
            CreateMap<CreateJobOfferCommand, JobOffer>();
            CreateMap<CreateJobOfferCommand, JobOfferMain>()
                .ForMember(x => x.CompanyLogo, o => o.MapFrom( s => Convert.FromBase64String(s.CompanyLogo)));

            CreateMap<UpdateJobOfferCommand, JobOfferMain>()
                .ForMember(x => x.CompanyLogo, o => o.MapFrom(s => Convert.FromBase64String(s.CompanyLogo)));

            CreateMap<JobOffer, JobOfferDto>();
            CreateMap<JobOfferMain, JobOfferDto>()
                .ForMember(x => x.CompanyLogo, o => o.MapFrom(s => Convert.ToBase64String(s.CompanyLogo)));
        }
    }
}