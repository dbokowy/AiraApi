using Aira.Application.Creator.Uow.Interface;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;
using static Azure.Core.HttpHeader;

namespace Aira.Domain.Business.Creator.Command
{
    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, Guid>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public CreateJobOfferCommandHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
        }
        public async Task<Guid> Handle(CreateJobOfferCommand command, CancellationToken cancellationToken)
        {
            await _jobOfferUnitOfWork.BeginTransaction();
            var jobOfferId = Guid.NewGuid();

            var jobOffer = _mapper.Map<CreateJobOfferCommand, JobOffer>(command);
            jobOffer.JobOfferId = jobOfferId;
            jobOffer.CreatedAt = DateTime.UtcNow;
            jobOffer.UserId = Guid.Empty;
            await _jobOfferUnitOfWork.JobOfferRepository.Insert(jobOffer);

            var jobOfferMain = _mapper.Map<CreateJobOfferCommand, JobOfferMain>(command);
            jobOfferMain.JobOfferId = jobOfferId;
            await _jobOfferUnitOfWork.JobOfferMainRepository.Insert(jobOfferMain);

            await _jobOfferUnitOfWork.Save();
            //TODO:: add virtual records with only jobOfferId in all jobOffer  tables 
            
            await _jobOfferUnitOfWork.Commit();

            return jobOfferId;
        }
    }
}
