using Aira.Application.Creator.Uow.Interface;
using Aira.Domain.Business.Creator.Dto;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;

namespace Aira.Domain.Business.Creator.Queries.Handlers
{
    public class GetJobOfferAdditionalInfoQueryHandler : IRequestHandler<GetJobOfferAdditionalInfoQuery, JobOfferAdditionalInfoDto>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public GetJobOfferAdditionalInfoQueryHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
            _mapper = mapper;
        }

        public async Task<JobOfferAdditionalInfoDto> Handle(GetJobOfferAdditionalInfoQuery request, CancellationToken cancellationToken)
        {
            var jobOfferAdditionalInfo = await _jobOfferUnitOfWork.JobOfferAdditionalInfoRepository.GetById(request.JobOfferId);
            return _mapper.Map<JobOfferAdditionalInfo, JobOfferAdditionalInfoDto>(jobOfferAdditionalInfo);
        }
    }
}