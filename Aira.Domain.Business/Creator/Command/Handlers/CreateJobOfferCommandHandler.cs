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

            await _jobOfferUnitOfWork.Save();

            var jobOfferMain = _mapper.Map<CreateJobOfferCommand, JobOfferMain>(command);
            jobOfferMain.JobOfferId = jobOfferId;
            await _jobOfferUnitOfWork.JobOfferMainRepository.Insert(jobOfferMain);

            await _jobOfferUnitOfWork.Save();

            await _jobOfferUnitOfWork.Commit();

            return jobOfferId;
        }
    }
}
