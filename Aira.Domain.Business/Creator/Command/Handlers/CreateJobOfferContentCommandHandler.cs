using Aira.Application.Creator.Uow.Interface;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;
using static Azure.Core.HttpHeader;

namespace Aira.Domain.Business.Creator.Command
{
    public class CreateJobOfferContentCommandHandler : IRequestHandler<CreateJobOfferContentCommand, Unit>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public CreateJobOfferContentCommandHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
        }
        public async Task<Unit> Handle(CreateJobOfferContentCommand command, CancellationToken cancellationToken)
        {
            await _jobOfferUnitOfWork.BeginTransaction();

            var jobOfferContent = _mapper.Map<CreateJobOfferContentCommand, JobOfferContent>(command);
            //jobOffer.CreatedAt = DateTime.UtcNow; :: TODO - add to db
            await _jobOfferUnitOfWork.JobOfferContentRepository.Insert(jobOfferContent);

            var jobOfferMain = _mapper.Map<CreateJobOfferContentCommand, JobOfferContentEducation>(command);
            await _jobOfferUnitOfWork.JobOfferContentEducationRepository.Insert(jobOfferMain);

            await _jobOfferUnitOfWork.Save();
            await _jobOfferUnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
