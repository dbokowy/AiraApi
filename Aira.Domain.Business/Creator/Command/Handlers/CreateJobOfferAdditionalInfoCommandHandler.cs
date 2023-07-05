using Aira.Application.Creator.Uow.Interface;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;
using static Azure.Core.HttpHeader;

namespace Aira.Domain.Business.Creator.Command
{
    public class CreateJobOfferAdditionalInfoCommandHandler : IRequestHandler<CreateJobOfferAdditionalInfoCommand, Unit>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public CreateJobOfferAdditionalInfoCommandHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
        }
        public async Task<Unit> Handle(CreateJobOfferAdditionalInfoCommand command, CancellationToken cancellationToken)
        {
            await _jobOfferUnitOfWork.BeginTransaction();

            var jobOfferAdditionalInfo = _mapper.Map<CreateJobOfferAdditionalInfoCommand, JobOfferAdditionalInfo>(command);
            //jobOffer.CreatedAt = DateTime.UtcNow; :: TODO - add to db
            await _jobOfferUnitOfWork.JobOfferAdditionalInfoRepository.Insert(jobOfferAdditionalInfo);

            await _jobOfferUnitOfWork.Save();
            await _jobOfferUnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
