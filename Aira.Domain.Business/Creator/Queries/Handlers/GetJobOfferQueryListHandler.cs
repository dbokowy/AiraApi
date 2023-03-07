using Aira.Application.Creator.Uow.Interface;
using Aira.Domain.Business.Creator.Dto;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;

namespace Aira.Domain.Business.Creator.Queries.Handlers
{
    public class GetJobOfferQueryListHandler : IRequestHandler<GetJobOfferListQuery, List<JobOfferDto>>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public GetJobOfferQueryListHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
            _mapper = mapper;
        }

        public async Task<List<JobOfferDto>> Handle(GetJobOfferListQuery request, CancellationToken cancellationToken)
        {
            //TODO::brac id z naglowka
            var jobOffer = await _jobOfferUnitOfWork.JobOfferRepository.GetAll();
            var jobOfferListDto = _mapper.Map<IEnumerable<JobOffer>, List<JobOfferDto>>(jobOffer);
            var jobOfferMainListDto = await _jobOfferUnitOfWork.JobOfferMainRepository.GetAll();
            
            //TODO::dodac paginacje

            jobOfferListDto.ForEach(o => {
                    var jobOffer = jobOfferMainListDto.FirstOrDefault(p => o.JobOfferId == p.JobOfferId);

                    o.SalaryFrom = jobOffer.SalaryFrom;
                    //o.SalaryCurrency = jobOffer.SalaryCurrency;
                    o.SalaryTime = jobOffer.SalaryTime;
                    o.SalaryTo = jobOffer.SalaryTo;
                    o.SalaryType = jobOffer.SalaryType;
                    o.AddressCity = jobOffer.AddressCity;
                    o.AddressCountry = jobOffer.AddressCountry;
                    o.AddressStreet = jobOffer.AddressStreet;
                    o.CompanyDescription = jobOffer.CompanyDescription;
                    //o.CompanyLogo = jobOffer.CompanyLogo;
                    o.CompanyName = jobOffer.CompanyName;
                    o.ContractType = jobOffer.ContractType;
                    o.RecruitmentMode = jobOffer.RecruitmentMode;
                    o.WorkMode = jobOffer.WorkMode;
                    o.WorkModel = jobOffer.WorkModel;
                    o.VacancyNumber = jobOffer.VacancyNumber;
                }
            );

            return jobOfferListDto;
        }
    }
}