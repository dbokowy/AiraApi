using Aira.Application.Creator.Uow.Interface;
using Aira.Persistence.Aira.Models;
using AutoMapper;
using MediatR;

namespace Aira.Domain.Business.Creator.Command
{
    public class UpdateJobOfferCompanyLogoCommandHandler : IRequestHandler<UpdateJobOfferCommand,Unit>
    {
        private readonly IJobOfferUnitOfWork _jobOfferUnitOfWork;
        private readonly IMapper _mapper;

        public UpdateJobOfferCompanyLogoCommandHandler(IJobOfferUnitOfWork jobOfferUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _jobOfferUnitOfWork = jobOfferUnitOfWork;
        }
        public async Task<Unit> Handle(UpdateJobOfferCommand command, CancellationToken cancellationToken)
        {

            return Unit.Value;
        }
    }
}