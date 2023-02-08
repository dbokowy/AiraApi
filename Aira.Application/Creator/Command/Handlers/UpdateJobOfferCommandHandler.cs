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

            var jobOfferMain = await _jobOfferUnitOfWork.JobOfferMainRepository.GetById(command.JobOfferId);
            jobOfferMain.SalaryFrom = command.SalaryFrom;
            //jobOfferMain.VacancyNumber = (byte)command.VacancyNumber;
            jobOfferMain.CompanyName = command.CompanyName;
            jobOfferMain.CompanyDescription = command.CompanyDescription;
            //jobOfferMain.CompanyLogo = command.CompanyLogo;
            jobOfferMain.CompanyName = command.CompanyName;
            jobOfferMain.ContractType = command.CompanyName;
            jobOfferMain.LocationCity = command.CompanyName;
            jobOfferMain.LocationDetails = command.CompanyName;
            jobOfferMain.LocationVoivodeship = command.CompanyName;
            jobOfferMain.LocationCountry = command.CompanyName;
            jobOfferMain.SalaryTime = command.SalaryTime;
            jobOfferMain.SalaryTo = command.SalaryTo;
            jobOfferMain.SalaryType = command.SalaryType;

            await _jobOfferUnitOfWork.JobOfferMainRepository.Update(jobOfferMain);

            await _jobOfferUnitOfWork.Save();

            return Unit.Value;
        }
    }
}