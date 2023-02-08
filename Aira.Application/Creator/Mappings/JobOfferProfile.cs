using Aira.Domain.Business.Creator.Command;
using Aira.Domain.Business.Creator.Dto;
using Aira.Persistence.Aira.Models;
using AutoMapper;

namespace Aira.Domain.Business.Creator.Mappings
{
    public class JobOfferProfile : Profile
    {
        public JobOfferProfile()
        {
            CreateMap<CreateJobOfferCommand, JobOffer>();
            CreateMap<CreateJobOfferCommand, JobOfferMain>();

            CreateMap<JobOffer, JobOfferDto>();
            CreateMap<JobOfferMain, JobOfferDto>();
        }
    }
}