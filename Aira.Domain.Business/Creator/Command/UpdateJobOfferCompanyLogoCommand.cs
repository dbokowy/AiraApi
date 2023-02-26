using MediatR;

namespace Aira.Domain.Business.Creator.Command
{
    public class UpdateJobOfferCompanyLogoCommand : IRequest
    {
        public int? VacancyNumber { get; set; }
    }
}