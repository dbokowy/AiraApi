using Aira.Application.Creator.Uow.Interface;
using Aira.Domain.Business.Creator.Dto;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;

namespace Aira.Domain.Business.Creator.Queries.Handlers
{
    public class GetJobOfferContentQueryHandler : IRequestHandler<GetJobOfferContentQuery, JobOfferContentDto>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public GetJobOfferContentQueryHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
            _mapper = mapper;
        }

        public async Task<JobOfferContentDto> Handle(GetJobOfferContentQuery request, CancellationToken cancellationToken)
        {
            var jobOfferContent = await _jobOfferUnitOfWork.JobOfferContentRepository.GetById(request.JobOfferId);
            var jobOfferContentDto = _mapper.Map<JobOfferContent, JobOfferContentDto>(jobOfferContent);
            var jobOfferContentEducationDto = await _jobOfferUnitOfWork.JobOfferContentEducationRepository.GetById(request.JobOfferId);
            return _mapper.Map<JobOfferContentEducation, JobOfferContentDto>(jobOfferContentEducationDto, jobOfferContentDto);
        }
    }
}