using Aira.Application.Creator.Uow.Interface;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;

namespace Aira.Domain.Business.Creator.Command
{
    public class UpdateJobOfferCommandHandler : IRequestHandler<UpdateJobOfferCommand,Unit>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public UpdateJobOfferCommandHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
        }
        public async Task<Unit> Handle(UpdateJobOfferCommand command, CancellationToken cancellationToken)
        {
            await _jobOfferUnitOfWork.BeginTransaction();

            var jobOffer = await _jobOfferUnitOfWork.JobOfferRepository.GetById(command.JobOfferId);
            jobOffer.Name = command.Name;
            jobOffer.PositionName = command.PositionName;
            await _jobOfferUnitOfWork.JobOfferRepository.Update(jobOffer);
            await _jobOfferUnitOfWork.Save();

            var jobOfferMain = await _jobOfferUnitOfWork.JobOfferMainRepository.GetById(command.JobOfferId);
            var jobOfferMainUpdated = _mapper.Map<UpdateJobOfferCommand, JobOfferMain>(command, jobOfferMain);

            await _jobOfferUnitOfWork.JobOfferMainRepository.Update(jobOfferMainUpdated);

            await _jobOfferUnitOfWork.Save();

            await _jobOfferUnitOfWork.Commit();

            return Unit.Value;
        }
    }
}