using Aira.Application.Creator.Uow.Interface;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;

namespace Aira.Domain.Business.Creator.Command
{
    public class UpdateJobOfferAdditionalInfoCommandHandler : IRequestHandler<UpdateJobOfferAdditionalInfoCommand, Unit>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public UpdateJobOfferAdditionalInfoCommandHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
        }
        public async Task<Unit> Handle(UpdateJobOfferAdditionalInfoCommand command, CancellationToken cancellationToken)
        {
            await _jobOfferUnitOfWork.BeginTransaction();

            var jobOfferAdditionalInfo = await _jobOfferUnitOfWork.JobOfferAdditionalInfoRepository.GetById(command.JobOfferId);
            var jobOfferAdditionalInfoUpdated = _mapper.Map<UpdateJobOfferAdditionalInfoCommand, JobOfferAdditionalInfo>(command, jobOfferAdditionalInfo);

            await _jobOfferUnitOfWork.JobOfferAdditionalInfoRepository.Update(jobOfferAdditionalInfoUpdated);

            await _jobOfferUnitOfWork.Save();

            await _jobOfferUnitOfWork.Commit();

            return Unit.Value;
        }
    }
}