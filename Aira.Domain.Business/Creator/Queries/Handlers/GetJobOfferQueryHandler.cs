using Aira.Application.Creator.Uow.Interface;
using Aira.Domain.Business.Creator.Dto;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aira.Domain.Business.Creator.Queries.Handlers
{
    public class GetJobOfferQueryHandler : IRequestHandler<GetJobOfferQuery, JobOfferDto>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public GetJobOfferQueryHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
            _mapper = mapper;
        }

        public async Task<JobOfferDto> Handle(GetJobOfferQuery request, CancellationToken cancellationToken)
        {
            var jobOffer = await _jobOfferUnitOfWork.JobOfferRepository.GetById(request.JobOfferId);
            var jobOfferDto = _mapper.Map<JobOffer,JobOfferDto>(jobOffer);
            var jobOfferMain = await _jobOfferUnitOfWork.JobOfferMainRepository.GetById(request.JobOfferId);
            return _mapper.Map<JobOfferMain, JobOfferDto>(jobOfferMain, jobOfferDto);
        }
    }
}