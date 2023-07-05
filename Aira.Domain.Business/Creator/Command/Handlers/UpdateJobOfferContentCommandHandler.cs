using Aira.Application.Creator.Uow.Interface;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;

namespace Aira.Domain.Business.Creator.Command
{
    public class UpdateJobOfferContentCommandHandler : IRequestHandler<UpdateJobOfferContentCommand,Unit>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public UpdateJobOfferContentCommandHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
        }
        public async Task<Unit> Handle(UpdateJobOfferContentCommand command, CancellationToken cancellationToken)
        {
            await _jobOfferUnitOfWork.BeginTransaction();

            var jobOffer = await _jobOfferUnitOfWork.JobOfferContentRepository.GetById(command.JobOfferId);
            await _jobOfferUnitOfWork.JobOfferContentRepository.Update(jobOffer);

            var jobOfferContent = await _jobOfferUnitOfWork.JobOfferContentEducationRepository.GetById(command.JobOfferId);
            var jobOfferContentUpdated = _mapper.Map<UpdateJobOfferContentCommand, JobOfferContentEducation>(command, jobOfferContent);

            await _jobOfferUnitOfWork.JobOfferContentEducationRepository.Update(jobOfferContentUpdated);

            await _jobOfferUnitOfWork.Save();

            await _jobOfferUnitOfWork.Commit();

            return Unit.Value;
        }
    }
}